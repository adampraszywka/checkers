using Domain.Shared;

namespace WebApi.Players;

public record SignalRPlayer(string Id) : Player
{
    public string Type => "SignalR";
}