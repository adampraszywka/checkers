using Contracts.Dto;

namespace WebApi.Hubs;

public interface DashboardHubClient
{
    public Task LobbiesUpdated(IEnumerable<GameLobbyDto> gameLobbies);
}