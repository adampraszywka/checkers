using AIPlayers.Repository;
using Contracts.AiPlayers;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AIPlayers.MessageHub;

public class Hub(
    AIAlgorithmFactory algorithmFactory,
    AIPlayerRepository aiPlayerRepository,
    ILoggerFactory loggerFactory,
    IRequestClient<MoveRequested> client,
    IPublishEndpoint publishEndpoint,
    ILogger<Hub> logger): IConsumer<GameProgressChanged>
{
    public async Task Consume(ConsumeContext<GameProgressChanged> context)
    {
        var message = context.Message;
        var participant = message.Participant;
        var board = message.Board;
        
        var player = await aiPlayerRepository.Get(participant.Id);
        if (player is null)
        {
            logger.LogInformation("No AI Player found for {PlayerId}", participant.Id);
            return;
        }
        
        var playerImplementation = algorithmFactory.Create(player);
        
        var moveClient = new MassTransitMoveClient(client, loggerFactory.CreateLogger<MassTransitMoveClient>(), board.Id, participant.Id);
        var publisher = new MassTransitStatusPublisher(board.Id, publishEndpoint);
        var configuration = new Configuration(player.Configuration);
        var services = new Services(moveClient, publisher, configuration);

        await playerImplementation.Move(participant, board, services);
    }
}