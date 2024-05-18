using AIPlayers.MessageHub;
using Anthropic.SDK;
using Anthropic.SDK.Messaging;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Algorithms.AnthropicClaude;

public class PlayerChat(AnthropicClient client, StatusPublisher statusPublisher)
{
    private const string Model = "claude-3-opus-20240229";
    private const string Context = "Claude-Player";
    private const string SystemPrompt = $@"You are the checkers master. You choose the best possible next move.
        User provides you information about whoose turn to play is.
        {Rules.Game}

        You expect following parameters to decide about the best possible move:
        - current state of the board
        - color of the player whoose turn is to play

        {Rules.BoardFormat}

        You list possible moves and than provide the best possible MOVE IN THE FOLLOWING FORMAT:
        
        BEST MOVE IS [SOURCE] TO [DESTINATION]";

    private readonly List<Message> _messages = [];

    public async Task<string> Prompt(string prompt)
    {
        _messages.Add(new Message(RoleType.User, prompt));
        
        var parameters = new MessageParameters
        {
            SystemMessage = SystemPrompt, 
            Temperature = 0,
            Model = Model,
            MaxTokens = 500,
            Messages = _messages
        };
        
        await statusPublisher.Publish(Status.Command(Context, _messages.DumpMessages(SystemPrompt)));
        var response = await client.Messages.GetClaudeMessageAsync(parameters);
        var result = response.Message.ToString();
        
        await statusPublisher.Publish(Status.Successful(Context, result));
        
        _messages.Add(new Message(RoleType.Assistant, result));

        return result;
    }
}