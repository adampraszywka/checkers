using Contracts.AiPlayers;
using MassTransit;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Players.OpenAIGpt4Turbo;

public class RefereeChat(string boardId, IOpenAIService client, IPublishEndpoint publishEndpoint)
{
    private const string Model = "gpt-4-turbo";
    private const string Context = "GPT-Referee";
    private const string SystemPrompt = $@"You are a checkers referee. 
            Your job is to decide weather of not move is valid and provide a reason why it's not valid if it's not valid.
            {Rules.Game}

            You expect the following parameters to decide if the move is valid:
            - current state of the board
            - requested move

            {Rules.BoardFormat}

            Requested move is provided in the following format:
            MOVE <SOURCE> TO <DESTINATION>

            
            Describe why move is valid or not valid and summarize using the following format:
            ```format
            Valid: <RESULT>
            <RESULT> may be Yes or No

            If move is not valid add:
            Reason: <REASON>";


    public async Task<string> Check(string boardState, string playerColor, string move)
    {
        var refereeMessage = $@"Current player: {playerColor}


                                ```state of the board
                                {boardState}


                                ```move 
                                {move}";
        var chatMessages = new List<ChatMessage>
        {
            ChatMessage.FromSystem(SystemPrompt),
            ChatMessage.FromUser(refereeMessage),
        };
        var refereePrompt = new ChatCompletionCreateRequest
        {
            Model = Model,
            Messages = chatMessages,
            Temperature = 0.2f
        };

        await PublishStatus(Status.Command(Context, chatMessages.DumpMessages()));

        var response = await client.ChatCompletion.CreateCompletion(refereePrompt);
        var responseContent = response.Choices.First().Message.Content!;

        await PublishStatus(Status.Successful(Context, responseContent));
        
        return responseContent;
    }
    
    private async Task PublishStatus(Status status)
    {
        await publishEndpoint.Publish(new AiPlayerStatusUpdated(boardId, [status]));
    }
}