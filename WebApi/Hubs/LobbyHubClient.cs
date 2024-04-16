using WebApi.Dto.Response;

namespace WebApi.Hubs;

public interface LobbyHubClient
{
    public Task LobbyUpdated(GameLobbyDto gameLobby);
}