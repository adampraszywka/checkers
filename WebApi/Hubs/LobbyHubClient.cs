using Contracts.Dto;

namespace WebApi.Hubs;

public interface LobbyHubClient
{
    public Task LobbyUpdated(GameLobbyDto gameLobby);
}