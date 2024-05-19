namespace AIPlayers.Players;

public record Algorithm(Type Value)
{
    public string Name => Value.Name;   
}