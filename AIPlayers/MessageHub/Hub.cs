using AIPlayers.Players.AnthropicClaude;
using AIPlayers.Players.Dummy;
using AIPlayers.Players.OpenAIGpt4o;
using AIPlayers.Players.OpenAIGpt4Turbo;
using Contracts.AiPlayers;
using Contracts.Players;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AIPlayers.MessageHub;

public class Hub(IPublishEndpoint publishEndpoint, ILogger<Hub> logger): IConsumer<GameProgressChanged>
{
    public async Task Consume(ConsumeContext<GameProgressChanged> context)
    {
        var message = context.Message;
        var participant = message.Participant;
        var board = message.Board;
        
        if (participant.Type == AIDummyPlayer.TypeValue)
        {
            var e = new DummyPlayerGameStateChanged(board, participant);
            await publishEndpoint.Publish(e);
            logger.LogInformation("Notified {Player} {PlayerId} about board {BoardId} update", typeof(AIDummyPlayer), participant.Id, board.Id);
            return;
        }

        if (participant.Type == OpenAiGpt4TurboPlayer.TypeValue)
        {
            var e = new OpenAiGpt4TurboPlayerGameStateChanged(board, participant);
            await publishEndpoint.Publish(e);
            logger.LogInformation("Notified {Player} {PlayerId} about board {BoardId} update", typeof(OpenAiGpt4TurboPlayer), participant.Id, board.Id);
            return;
        }
        

        if (participant.Type == OpenAiGpt4oPlayer.TypeValue)
        {
            var e = new OpenAiGpt4oPlayerGameStateChanged(board, participant);
            await publishEndpoint.Publish(e);
            logger.LogInformation("Notified {Player} {PlayerId} about board {BoardId} update", typeof(OpenAiGpt4TurboPlayer), participant.Id, board.Id);
            return;
        }
        
        if (participant.Type == AnthropicClaudePlayer.TypeValue)
        {
            var e = new AntrophicClaudeGamePlayerGameStateChanged(board, participant);
            await publishEndpoint.Publish(e);
            logger.LogInformation("Notified {Player} {PlayerId} about board {BoardId} update", typeof(AnthropicClaudePlayer), participant.Id, board.Id);
            return;
        }

        logger.LogInformation("Player {PlayerId} from {BoardId} is not an AI player", participant.Id, board.Id);
    }
}