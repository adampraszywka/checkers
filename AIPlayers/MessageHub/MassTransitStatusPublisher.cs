using Contracts.AiPlayers;
using MassTransit;

namespace AIPlayers.MessageHub;

public class MassTransitStatusPublisher(ScopedHubContext context, IPublishEndpoint publishEndpoint) : StatusPublisher
{
    public Task Publish(AiPlayerStatus entry) => Publish([entry]);

    public Task Publish(IEnumerable<AiPlayerStatus> entries)
    {
        return publishEndpoint.Publish(new AiPlayerStatusUpdated(context.BoardId, entries));
    }
}