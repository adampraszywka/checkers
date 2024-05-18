using AIPlayers.Players;

namespace AIPlayers.MessageHub;

public interface AIAlgorithmFactory
{
    public AIAlgorithm Create(AlgorithmPlayer player);
}
