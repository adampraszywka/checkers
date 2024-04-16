using MassTransit;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;
using WebApi.Messages.Notification;

namespace WebApi.Consumers.Notification;

public class BoardUpdatedConsumer(IHubContext<BoardHub, BoardHubClient> hubContext) : IConsumer<BoardUpdated>
{
    public async Task Consume(ConsumeContext<BoardUpdated> context)
    {
        var board = context.Message.Board;
        var players = context.Message.NotifiableParticipants;
        
        await hubContext.Clients.Group(board.Id).BoardUpdated(board);
    }
}