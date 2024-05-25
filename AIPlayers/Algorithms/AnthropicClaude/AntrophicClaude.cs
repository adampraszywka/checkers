using System.Text.RegularExpressions;
using AIPlayers.Algorithms.Shared;
using AIPlayers.Extensions;
using AIPlayers.MessageHub;
using Anthropic.SDK;
using Contracts.Dto;
using Microsoft.Extensions.Logging;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Algorithms.AnthropicClaude;

public class AntrophicClaude(
    AnthropicClient client, 
    ILogger<AntrophicClaude> logger,
    MoveClient moveClient,
    StatusPublisher statusPublisher, 
    AiAlgorithmConfiguration configuration) : AIAlgorithm
{
    private const int MaxFindMoveIterations = 3;
    private const int MaxMoveIterations = 3;
    
    public async ValueTask Move(ParticipantDto participant, BoardDto board)
    {
        var color = participant.Color;
        if (color != board.CurrentPlayer)
        {
            logger.LogInformation("It's not the AI player's turn");
            return;
        }
        
        var boardState = board.ToBoardState();
        var currentPlayer = $"Current player: {color}";
        
        var playerChat = new PlayerChat(client, statusPublisher);
        var playerPrompt = $"{boardState}\n{currentPlayer}";
        
        var counter = 0;
        while (counter < MaxMoveIterations)
        {
            var (f, t) = await FindMove(playerChat, playerPrompt);

            var from = PositionDto.FromName(f);
            var to = PositionDto.FromName(t);
            
            var result = await Move(from, to);

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
            if (!TryExtractMove(playerResult, out _, out var from, out var to))
            {
                logger.LogError("Move Regex match failed for player result: {PlayerResult}", playerResult);
            }
            
            return (from, to);
        }

        return ("", "");
    }

    private async Task<(bool IsSuccessful, string ErrorMessage)> Move(PositionDto from, PositionDto to)
    {
        var move = new MoveDto(from, to);
        var response = await moveClient.Move(move);

        await statusPublisher.Publish(Status.Command("API", $"Move from {from.ToName()} to {to.ToName()}"));

        if (response.IsSuccess)
        {
            await statusPublisher.Publish(Status.Successful("API", $"Move from {from.ToName()} to {to.ToName()} successful"));
            return (true, "");
        }
        
        var error = response.Errors.First().Message ?? "Unknown error";
        await statusPublisher.Publish(Status.Failed("API", $"Move from {from.ToName()} to {to.ToName()} failed: {error}"));
        return (false, error);
    }

    private bool TryExtractMove(string input, out string raw, out string from, out string to)
    {
        const string pattern = @"(?<=\bBEST MOVE IS\s)(\w+\d+)\sTO\s(\w+\d+)";
        
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
}