namespace AIPlayers.Players;

public record Algorithm(Type Implementation)
{
    public string Name => Implementation.Name;   
}