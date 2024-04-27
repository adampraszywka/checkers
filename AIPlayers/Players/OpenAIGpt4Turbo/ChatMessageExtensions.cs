using OpenAI.ObjectModels.RequestModels;

namespace AIPlayers.Players.OpenAIGpt4Turbo;

public static class ChatMessageExtensions
{
    public static string DumpMessages(this List<ChatMessage> messages) => DumpMessages(messages.AsEnumerable());
    public static string DumpMessages(this IEnumerable<ChatMessage> messages)
    {
        return string.Join("\n", messages.Select(x => x.Content));
    }
}