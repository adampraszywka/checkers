using AIPlayers.Players.Dummy;
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
            logger.LogInformation("Notified AIDummyPlayer {PlayerId} about board {BoardId} update", participant.Id, board.Id);
            return;
        }

        logger.LogInformation("Player {PlayerId} from {BoardId} is not an AI player", participant.Id, board.Id);
    }
}