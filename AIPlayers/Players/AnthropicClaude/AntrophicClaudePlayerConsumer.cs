using System.Text.RegularExpressions;
using AIPlayers.Extensions;
using AIPlayers.Players.Shared;
using Anthropic.SDK;
using Contracts.AiPlayers;
using Contracts.Dto;
using Contracts.Players;
using MassTransit;
using Microsoft.Extensions.Logging;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Players.AnthropicClaude;

public class AntrophicClaudePlayerConsumer(
    AnthropicClient client, 
    IPublishEndpoint publishEndpoint,
    IRequestClient<MoveRequested> moveClient,
    ILogger<AntrophicClaudePlayerConsumer> logger) : IConsumer<AntrophicClaudeGamePlayerGameStateChanged>
{
   private const int MaxFindMoveIterations = 3;
    private const int MaxMoveIterations = 3;

    
    public async Task Consume(ConsumeContext<AntrophicClaudeGamePlayerGameStateChanged> context)
    {
        var color = context.Message.Participant.Color;
        var board = context.Message.Board;
        
        if (color != board.CurrentPlayer)
        {
            logger.LogInformation("It's not the AI player's turn");
            return;
        }

        var boardId = board.Id;
        var playerId = context.Message.Participant.Id;
        var boardState = context.Message.Board.ToBoardState();
        var currentPlayer = $"Current player: {color}";
        
        var playerChat = new PlayerChat(boardId, client, publishEndpoint);
        var playerPrompt = $"{boardState}\n{currentPlayer}";
        
        var counter = 0;
        while (counter < MaxMoveIterations)
        {
            var (f, t) = await FindMove(playerChat, playerPrompt);

            var from = PositionDto.FromName(f);
            var to = PositionDto.FromName(t);
            
            var result = await Move(from, to, playerId, boardId);

            if (!result.IsSuccessful)
            {
                playerPrompt = $"Move failed: {result.ErrorMessage}";
            }
            else
            {
                return;
            }
            
            counter++;
        }
    }

    private async Task<(string From, string To)> FindMove(PlayerChat playerChat, string initialPlayerPrompt)
    {
        var playerPrompt = initialPlayerPrompt;
        var counter = 0;
        
        while (counter <= MaxFindMoveIterations) {
            var playerResult = await playerChat.Prompt(playerPrompt);
            if (!TryExtractMove(playerResult, out var _, out var from, out var to))
            {
                logger.LogError("Move Regex match failed for player result: {PlayerResult}", playerResult);
            }
            
            return (from, to);
        }

        return ("", "");
    }

    private async Task<(bool IsSuccessful, string ErrorMessage)> Move(PositionDto from, PositionDto to, string playerId, string boardId)
    {
        var move = new MoveDto(from, to);
        var player = new PlayerDto(playerId, OpenAiGpt4TurboPlayer.TypeValue);
        var e = new MoveRequested(boardId, player, move);
        var response = await moveClient.GetResponse<MoveSucceeded, MoveFailed>(e);

        await PublishStatus(boardId, Status.Command("API", $"Move from {from.ToName()} to {to.ToName()}"));
                
        if (response.Is<MoveSucceeded>(out _))
        {
            await PublishStatus(boardId, Status.Successful("API", $"Move from {from.ToName()} to {to.ToName()} successful"));
            logger.LogInformation(
                "AI player {PlayerId} moved piece on board {BoardId} from {Position} to {NewPosition}", 
                playerId, 
                boardId,
                from.ToName(),
                to.ToName());
            return (true, "");
        }

        if (response.Is<MoveFailed>(out var moveFailed))
        {
            await PublishStatus(boardId, Status.Failed("API", $"Move from {from.ToName()} to {to.ToName()} failed: {moveFailed.Message.ErrorMessages.First()}"));
            logger.LogWarning("AI player {PlayerId} failed to move piece on board {BoardId} from {Position} to {NewPosition}. Reason: {Reason}",
                playerId,
                boardId,
                from.ToName(),
                to.ToName(),
                moveFailed.Message.ErrorMessages.First());     
            return (false, moveFailed.Message.ErrorMessages.First());
        }
        
        return (false, "Unknown error");
    }

    private bool TryExtractMove(string input, out string raw, out string from, out string to)
    {
        const string pattern = @"(?<=\bMOVE\s)(\w+\d+)\sTO\s(\w+\d+)";
        
        var match = Regex.Match(input, pattern);

        if (!match.Success)
        {
            raw = "";
            from = "";
            to = "";
            return false;
        }

        raw = match.Value;
        from = match.Groups[1].Value;
        to = match.Groups[2].Value;
        
        return true;
    }
    
    private (bool IsValid, string Reason) ExtractReason(string input)
    {
        if (input.Contains("Valid: Yes"))
        {
            return (true, "");
        }
        
        const string pattern = "(?<=Reason: )(.*)";

        var match = Regex.Match(input, pattern);

        if (!match.Success)
        {
            return (false, "Unparsable reason");
        }

        return (false, match.Value);
    }
    
    
    private async Task PublishStatus(string boardId, Status status)
    {
        await publishEndpoint.Publish(new AiPlayerStatusUpdated(boardId, [status]));
    }
}