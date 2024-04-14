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

    public async Task Save(GameLobby gameLobby)
    {
        var id = gameLobby.Id;
        _gameLobbies[id] = gameLobby;
    }

    public Task<IEnumerable<GameLobby>> GetAll()
    {
        var lobbies = _gameLobbies.Select(x => x.Value);
        return Task.FromResult(lobbies); 
    }
}