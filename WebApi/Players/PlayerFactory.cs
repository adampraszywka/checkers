using Contracts.Players;
using Domain.Shared;
using FluentResults;
using WebApi.Players.Error;

namespace WebApi.Players;

public class PlayerFactory
{
    public Result<Player> Create(string id, string type)
    {
        var player = CreatePlayer(id, type);
        if (player is null)
        {
            return Result.Fail(new InvalidAiPlayerType(type));
        }
        
        return Result.Ok(player);
    }
    
    private Player? CreatePlayer(string id, string type)
    {
        return type switch
        {
            AIDummyPlayer.TypeValue => new AIDummyPlayer(id),
            HeaderPlayer.TypeValue => new HeaderPlayer(id),
            SignalRPlayer.TypeValue => new SignalRPlayer(id),
            _ => null
        };
    }
}