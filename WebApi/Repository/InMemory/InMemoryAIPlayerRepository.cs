using AIPlayers.Players;
using AIPlayers.Repository;
using Jitbit.Utils;
using Microsoft.Extensions.Options;
using WebApi.Settings;

namespace WebApi.Repository.InMemory;

public class InMemoryAIPlayerRepository(IOptions<InMemoryStorageSettings> settings) : AIPlayerRepository
{
    private readonly FastCache<string, AlgorithmPlayer> _players = new();
    private readonly TimeSpan _timeToLive = settings.Value.TimeToLive;
    
    public Task<AlgorithmPlayer?> Get(string id)
    {
        if (!_players.TryGet(id, out var player))
        {
           return Task.FromResult<AlgorithmPlayer?>(null);
        }
        
        // We need to update the player's TTL. Board may get updated but player not. 
        // We want to refresh the TTL of the player when it is accessed.
        _players.AddOrUpdate(player.Id, player, _timeToLive);
        return Task.FromResult<AlgorithmPlayer?>(player);
    }

    public Task Save(AlgorithmPlayer player)
    {
        _players.AddOrUpdate(player.Id, player, _timeToLive);
        return Task.CompletedTask;
    }
}