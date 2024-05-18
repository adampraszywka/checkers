using Contracts.AiPlayers;

namespace AIPlayers.MessageHub;

public interface StatusPublisher
{
    public Task Publish(AiPlayerStatus entry);
    public Task Publish(IEnumerable<AiPlayerStatus> entries);
}