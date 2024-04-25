using Contracts.AiPlayers;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;

namespace WebApi.Consumers.AIInterface;

public class AiPlayerStatusUpdatedConsumer(IHubContext<AiStatusHub, AiStatusHubClient> hub) : IConsumer<AiPlayerStatusUpdated>
{
    public async Task Consume(ConsumeContext<AiPlayerStatusUpdated> context)
    {
        var message = context.Message;

        await hub.Clients.Group(message.BoardId).StatusUpdated(message);
    }
}