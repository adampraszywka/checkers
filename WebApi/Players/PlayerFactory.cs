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
        new(OpenAiGpt4oPlayer.TypeValue, nameof(OpenAiGpt4oPlayer)),
        new(OpenAiGpt4TurboPlayer.TypeValue, nameof(OpenAiGpt4TurboPlayer)),
        new(AnthropicClaudePlayer.TypeValue, nameof(AnthropicClaudePlayer)),
        new(AIDummyPlayer.TypeValue, nameof(AIDummyPlayer))
    ];
    
    private static Player? CreatePlayer(string id, string type)
    {
        return type switch
        {
            AIDummyPlayer.TypeValue => new AIDummyPlayer(id),
            OpenAiGpt4TurboPlayer.TypeValue => new OpenAiGpt4TurboPlayer(id),
            OpenAiGpt4oPlayer.TypeValue => new OpenAiGpt4oPlayer(id),
            AnthropicClaudePlayer.TypeValue => new AnthropicClaudePlayer(id),
            ApiPlayer.TypeValue => new ApiPlayer(id),
            SignalRPlayer.TypeValue => new SignalRPlayer(id),
            _ => null
        };
    }
}