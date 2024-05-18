using AIPlayers.Algorithms.Shared;
using AIPlayers.MessageHub;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Algorithms.OpenAIGpt4o;

public class PlayerChat(IOpenAIService client, StatusPublisher statusPublisher)
{
    private const string Model = "gpt-4o";
    private const string Context = "GPT4o-Player";
    private const string SystemPrompt = $@"You are the checkers master. You choose the best possible next move.
        User provides you information about whoose turn to play is.
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
        
        var playerPrompt = new ChatCompletionCreateRequest {Model = Model, Messages = _messages, Temperature = 0.2f};

        await statusPublisher.Publish(Status.Command(Context, _messages.DumpMessages()));
        
        var result = await client.ChatCompletion.CreateCompletion(playerPrompt);
        var resultContent = result.Choices.First().Message.Content!;

        await statusPublisher.Publish(Status.Successful(Context, resultContent));
        
        _messages.Add(ChatMessage.FromAssistant(resultContent));

        return resultContent;
    }
}