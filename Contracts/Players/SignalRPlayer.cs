using Domain.Shared;

namespace Contracts.Players;

public record SignalRPlayer(string Id) : Player
{
    public const string TypeValue = "SignalR";
    public string Type => TypeValue;
    public bool Bot => false;
}