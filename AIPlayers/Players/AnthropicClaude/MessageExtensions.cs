using Anthropic.SDK.Messaging;

namespace AIPlayers.Players.AnthropicClaude;

public static class MessageExtensions
{
    public static string DumpMessages(this List<Message> messages, string systemPrompt) => DumpMessages(messages.AsEnumerable(), systemPrompt);
    public static string DumpMessages(this IEnumerable<Message> messages, string systemPrompt)
    {
        return $"{systemPrompt}\n" + string.Join("\n", messages.Select(x => x.ToString()));
    }
}