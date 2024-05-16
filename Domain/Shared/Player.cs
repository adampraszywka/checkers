namespace Domain.Shared;

public interface Player
{
    public string Id { get; }
    public string Type { get; }
    public bool Bot { get; }
}