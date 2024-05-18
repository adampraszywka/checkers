using AIPlayers.Players;

namespace AIPlayers.Repository;

public interface AIPlayerRepository
{
    public Task<AlgorithmPlayer?> Get(string id);
    public Task Save(AlgorithmPlayer player);
}