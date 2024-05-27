using AIPlayers.Algorithms.Shared;
using AIPlayers.MessageHub;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Algorithms.OpenAIGpt4o;

public class PlayerChat(IOpenAIService client, StatusPublisher statusPublisher, OpenAiGpt4oConfiguration configuration)
{
    private const string SystemPrompt = $@"You are the checkers master.

        {Rules.Game}

        You expect following parameters to decide about the best possible move:
        - current state of the board
        - color of the player whoose turn is to play

        {Rules.BoardFormat}

        You list possible moves and than provide the best possible MOVE IN THE FOLLOWING FORMAT:
        ```format
        MOVE <SOURCE> TO <DESTINATION>";

    private readonly List<ChatMessage> _messages = [ChatMessage.FromSystem(SystemPrompt)];

    public async Task<string> Prompt(string prompt)
    {
        _messages.Add(ChatMessage.FromUser(prompt));
        
        var playerPrompt = new ChatCompletionCreateRequest {Model = configuration.Model, Messages = _messages, Temperature = configuration.Temperature};

        await statusPublisher.Publish(Status.Command(Context, _messages.DumpMessages()));
        
        var result = await client.ChatCompletion.CreateCompletion(playerPrompt);
        var resultContent = result.Choices.First().Message.Content!;

        await statusPublisher.Publish(Status.Successful(Context, resultContent));
        
        _messages.Add(ChatMessage.FromAssistant(resultContent));

        return resultContent;
    }
    
    private string Context => configuration.Model + "-Player";
}