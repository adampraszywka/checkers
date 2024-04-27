using AIPlayers.Players.Dummy;
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
            var e = new DummyPlayerGameProgressChanged(board, participant);
            await publishEndpoint.Publish(e);
            logger.LogInformation("Notified {Player} {PlayerId} about board {BoardId} update", typeof(AIDummyPlayer), participant.Id, board.Id);
            return;
        }

        if (participant.Type == AiOpenAiGpt4TurboPlayer.TypeValue)
        {
            var e = new OpenAiGpt4TurboPlayerGameProgressChanged(board, participant);
            await publishEndpoint.Publish(e);
            logger.LogInformation("Notified {Player} {PlayerId} about board {BoardId} update", typeof(AiOpenAiGpt4TurboPlayer), participant.Id, board.Id);
            return;
        }

        logger.LogInformation("Player {PlayerId} from {BoardId} is not an AI player", participant.Id, board.Id);
    }
}