using Domain.Shared;

namespace AIPlayers.Players;

public record AlgorithmPlayer(string Id, string Algorithm, Dictionary<string, string> Configuration) : Player
{
    public string Type => "AI";
}