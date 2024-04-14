using Domain.Lobby;

namespace WebApi.Repository.InMemory;

public class InMemoryGameLobbyRepository : GameLobbyRepository, GameLobbyListRepository
{
    private readonly Dictionary<string, GameLobby> _gameLobbies = new();
    
    public Task<GameLobby?> Get(string id)
    {
        if (_gameLobbies.TryGetValue(id, out var lobby))
        {
            return Task.FromResult<GameLobby?>(lobby);
        }

        return Task.FromResult<GameLobby?>(null);
    }

    public Task Save(GameLobby gameLobby)
    {
        _gameLobbies[gameLobby.Id] = gameLobby;
        return Task.CompletedTask;
    }

    public Task<IEnumerable<GameLobby>> GetAll()
    {
        var lobbies = _gameLobbies.Select(x => x.Value);
        return Task.FromResult(lobbies); 
    }
}