using System.Text;
using OpenAI.ObjectModels.RequestModels;

namespace AIPlayers.Players.OpenAIGpt4o;

public static class ChatMessageExtensions
{
    public static string DumpMessages(this List<ChatMessage> messages) => DumpMessages(messages.AsEnumerable());
    public static string DumpMessages(this IEnumerable<ChatMessage> messages)
    {
        var output = new StringBuilder();
        
        foreach (var message in messages)
        {
            output.AppendLine("");
            output.AppendLine(Title(message.Role));
            output.AppendLine(message.Content);
        }

        return output.ToString();
    }

    private static string Title(string role)
    {
        return role switch
        {
            "system" => "========= SYSTEM =========",
            "user" => "========= USER =========",
            "assistant" => "========= ASSISTANT =========",
            "tool" => "========= TOOL =========",
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}