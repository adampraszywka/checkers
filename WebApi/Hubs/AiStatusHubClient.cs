using Contracts.AiPlayers;

namespace WebApi.Hubs;

public interface AiStatusHubClient
{
    public Task StatusUpdated(AiPlayerStatusUpdated message);
}