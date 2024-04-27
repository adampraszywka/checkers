using Domain.Shared;

namespace Contracts.Players;

public record AiOpenAiGpt4TurboPlayer(string Id) : Player
{
    public const string TypeValue = "AI_OpenAiGpt4Turbo";
    public string Type => TypeValue;
}