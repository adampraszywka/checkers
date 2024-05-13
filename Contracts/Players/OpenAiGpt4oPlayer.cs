using Domain.Shared;

namespace Contracts.Players;

public record OpenAiGpt4oPlayer(string Id) : Player
{
    public const string TypeValue = "OpenAiGpt4oPlayer";
    public string Type => TypeValue;
}