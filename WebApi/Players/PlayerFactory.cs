using Contracts.Players;
using Domain.Shared;

namespace WebApi.Players;

public class PlayerFactory
{
    public Player Create(string id, string type)
    {
        return type switch
        {
            AIDummyPlayer.TypeValue => new AIDummyPlayer(id),
            HeaderPlayer.TypeValue => new HeaderPlayer(id),
            SignalRPlayer.TypeValue => new SignalRPlayer(id),
            _ => throw new ArgumentException($"Invalid player type: {type}")
        };
    }
}