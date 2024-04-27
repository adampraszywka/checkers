using Contracts.Dto;
using Contracts.Players;
using Domain.Shared;
using FluentResults;
using WebApi.Players.Error;

namespace WebApi.Players;

public class PlayerFactory
{
    public static Result<Player> Create(string id, string type)
    {
        var player = CreatePlayer(id, type);
        if (player is null)
        {
            return Result.Fail(new InvalidAiPlayerType(type));
        }
        
        return Result.Ok(player);
    }

    public static IEnumerable<AiPlayer> AvailableAiPlayers =>
    [
        new(AIDummyPlayer.TypeValue, nameof(AIDummyPlayer)),
        new(AiOpenAiGpt4TurboPlayer.TypeValue, nameof(AiOpenAiGpt4TurboPlayer))
    ];
    
    private static Player? CreatePlayer(string id, string type)
    {
        return type switch
        {
            AIDummyPlayer.TypeValue => new AIDummyPlayer(id),
            AiOpenAiGpt4TurboPlayer.TypeValue => new AiOpenAiGpt4TurboPlayer(id),
            HeaderPlayer.TypeValue => new HeaderPlayer(id),
            SignalRPlayer.TypeValue => new SignalRPlayer(id),
            _ => null
        };
    }
}