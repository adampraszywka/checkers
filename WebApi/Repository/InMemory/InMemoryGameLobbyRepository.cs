using Domain.Lobby;
using Jitbit.Utils;
using Microsoft.Extensions.Options;
using WebApi.Settings;

namespace WebApi.Repository.InMemory;

public class InMemoryGameLobbyRepository(IOptions<InMemoryStorageSettings> settings) : GameLobbyRepository, GameLobbyListRepository
{
    private readonly FastCache<string, GameLobby> _gameLobbies = new();
    private readonly TimeSpan _timeToLive = settings.Value.TimeToLive;

    public Task<GameLobby?> Get(string id)
    {
        if (_gameLobbies.TryGet(id, out var lobby))
        {
            return Task.FromResult<GameLobby?>(lobby);
        }

        return Task.FromResult<GameLobby?>(null);
    }

    public Task Save(GameLobby gameLobby)
    {
        _gameLobbies.AddOrUpdate(gameLobby.Id, gameLobby, _timeToLive);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<GameLobby>> GetAll()
    {
        var lobbies = _gameLobbies.Select(x => x.Value);
        return Task.FromResult(lobbies); 
    }
}