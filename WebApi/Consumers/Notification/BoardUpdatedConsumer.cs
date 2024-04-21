using Contracts.AiPlayers;
using Contracts.Notification;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;

namespace WebApi.Consumers.Notification;

public class BoardUpdatedConsumer(
    IHubContext<BoardHub, BoardHubClient> hubContext,
    IPublishEndpoint publishEndpoint,
    ILogger<BoardUpdatedConsumer> logger) : IConsumer<BoardUpdated>
{
    public async Task Consume(ConsumeContext<BoardUpdated> context)
    {
        var board = context.Message.Board;
        var players = context.Message.NotifiableParticipants;
        
        await hubContext.Clients.Group(board.Id).BoardUpdated(board);
        logger.LogInformation("Notified SignalR group {GroupId} about board update", board.Id);
        
        foreach (var player in players)
        {
            var msg = new GameProgressChanged(board, player);
            await publishEndpoint.Publish(msg);
            logger.LogInformation("Notified player {PlayerId} about board update", player.Id);
        }
    }
}