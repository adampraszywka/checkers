using Domain.Lobby;

namespace WebApi.Repository;

public interface GameLobbyListRepository
{
    public Task<IEnumerable<GameLobby>> GetAll();
}