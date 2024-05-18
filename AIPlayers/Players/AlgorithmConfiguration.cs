namespace AIPlayers.Players;

public interface AlgorithmConfiguration
{
    public IEnumerable<AIPlayer> Available { get; }
}