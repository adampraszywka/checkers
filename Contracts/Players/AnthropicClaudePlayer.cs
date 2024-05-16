using Domain.Shared;

namespace Contracts.Players;

public record AnthropicClaudePlayer(string Id) : Player
{
    public const string TypeValue = "AI_AnthropicClaude";
    public string Type => TypeValue;
    public bool Bot => true;
}