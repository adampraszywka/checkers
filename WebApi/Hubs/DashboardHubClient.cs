using WebApi.Dto.Response;

namespace WebApi.Hubs;

public interface DashboardHubClient
{
    public Task LobbiesUpdated(IEnumerable<GameLobbyDto> gameLobbies);
}