namespace AIPlayers.Players;

public interface AlgorithmPlayerFactory
{
    public AlgorithmPlayer? Create(string id, string algorithm, Dictionary<string, string> configuration);
}