using Domain.Shared;

namespace WebApi.Players;

public record SignalRPlayer(string Id) : Player
{
    public const string TypeValue = "Human";
    public string Type => TypeValue;
}