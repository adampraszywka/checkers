using System.Text;
using GroqSharp.Models;

namespace AIPlayers.Algorithms.Shared;

public static class GroqMessageExtensions
{
    public static string DumpMessages(this List<Message> messages) => DumpMessages(messages.AsEnumerable());
    public static string DumpMessages(this IEnumerable<Message> messages)
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

    private static string Title(MessageRoleType role)
    {
        return role switch
        {
            MessageRoleType.System => "========= SYSTEM =========",
            MessageRoleType.User => "========= USER =========",
            MessageRoleType.Assistant => "========= ASSISTANT =========",
            MessageRoleType.Tool => "========= TOOL =========",
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}