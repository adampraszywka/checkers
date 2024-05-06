using System.Text;
using Anthropic.SDK.Messaging;

namespace AIPlayers.Players.AnthropicClaude;

public static class MessageExtensions
{
    public static string DumpMessages(this List<Message> messages, string systemPrompt) => DumpMessages(messages.AsEnumerable(), systemPrompt);
    public static string DumpMessages(this IEnumerable<Message> messages, string systemPrompt)
    {
        var output = new StringBuilder();

        output.AppendLine("========= SYSTEM =========");
        output.AppendLine(systemPrompt);

        foreach (var message in messages)
        {
            output.AppendLine("");
            output.AppendLine(message.Role == RoleType.User ? "========= USER =========" : "========= ASSISTANT =========");
            output.AppendLine(message.ToString());
        }

        return output.ToString();
    }
}