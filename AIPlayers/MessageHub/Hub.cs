using AIPlayers.Repository;
using Contracts.AiPlayers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AIPlayers.MessageHub;

public class Hub(
    AIPlayerRepository aiPlayerRepository,
    IServiceScopeFactory scopeFactory,
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
        
        using var scope = scopeFactory.CreateScope();
        
        var algorithmFactory = scope.ServiceProvider.GetRequiredService<AIAlgorithmFactory>();
        
        var scopedContext = scope.ServiceProvider.GetRequiredService<ScopedHubContext>();
        scopedContext.Configure(board.Id, participant.Id);
        
        var scopedConfiguration = scope.ServiceProvider.GetRequiredService<ScopedConfiguration>();
        scopedConfiguration.Configure(player.Configuration);
        
        var playerImplementation = algorithmFactory.Create(player);
        await playerImplementation.Move(participant, board);
    }
}