using AIPlayers.Algorithms.Shared;
using AIPlayers.MessageHub;
using GroqSharp.Models;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Algorithms.Llama;

public class PlayerChat(GroqClient client, StatusPublisher statusPublisher, Laama31Configuration configuration)
{
    private const string SystemPrompt = $@"You are the checkers master. You just drank a cup of coffee and are ready to play.

        {Rules.Game}

        You expect following parameters to decide about the best possible move:
        - current state of the board
        - color of the player whoose turn is to play

        {Rules.BoardFormat}

        You take a deep breath, list possible moves and than provide the best possible MOVE IN THE FOLLOWING FORMAT:
        ```format
        MOVE <SOURCE> TO <DESTINATION>";

    private readonly List<Message> _messages = new() {new Message {Role = MessageRoleType.System, Content = SystemPrompt}};

    public async Task<string> Prompt(string prompt)
    {
        _messages.Add(new Message {Role = MessageRoleType.User, Content = prompt});
        
        await statusPublisher.Publish(Status.Command(Context, _messages.DumpMessages()));

        client.SetTemperature(configuration.Temperature);
        var result = await client.CreateChatCompletionAsync(_messages.ToArray());

        if (result is null)
        {
            // Let's support this later
            throw new NotImplementedException();
        }

        await statusPublisher.Publish(Status.Successful(Context, result));
        
        _messages.Add(new Message {Role = MessageRoleType.Assistant, Content = result});

        return result;
    }
    
    private string Context => "Llama-Player";
}