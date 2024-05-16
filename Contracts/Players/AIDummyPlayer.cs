using Domain.Shared;

namespace Contracts.Players;

public record AIDummyPlayer(string Id) : Player
{
    public const string TypeValue = "AI_Dummy";
    
    public string Type => TypeValue;
    public bool Bot => true;
}