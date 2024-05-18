using AIPlayers.Players;

namespace AIPlayers.Repository;

public class InMemoryAIPlayerRepository : AIPlayerRepository
{
    private readonly Dictionary<string, AlgorithmPlayer> _players = new();
     
    public Task<AlgorithmPlayer?> Get(string id)
    {
        return Task.FromResult(_players.GetValueOrDefault(id));
    }

    public Task Save(AlgorithmPlayer player)
    {
        _players[player.Id] = player;
        return Task.CompletedTask;
    }
}