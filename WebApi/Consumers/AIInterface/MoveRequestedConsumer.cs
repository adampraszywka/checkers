using AIPlayers.Repository;
using Contracts.AiPlayers;
using MassTransit;
using WebApi.Extensions;
using WebApi.Service;

namespace WebApi.Consumers.AIInterface;

public class MoveRequestedConsumer(BoardService boardService, AIPlayerRepository aiPlayerRepository, ILogger<MoveRequestedConsumer> logger) : IConsumer<MoveRequested>
{
    public async Task Consume(ConsumeContext<MoveRequested> context)
    {
        var message = context.Message;

        var player = await aiPlayerRepository.Get(message.PlayerId);
        if (player is null)
        {
            logger.LogError("Player {PlayerId} not found. Aborting move for board {BoardId}", message.PlayerId, message.BoardId);
            return;
        }
        
        var from = message.Move.From.ToPosition();
        var to = message.Move.To.ToPosition();

        var result = await boardService.Move(message.BoardId, player, from, to);
        if (result.IsFailed)
        {
            var msg = new MoveFailed(result.Errors.Select(x => x.Message));
            await context.RespondAsync(msg);
            return;
        }

        var board = result.Value;
        await context.RespondAsync(new MoveSucceeded(board.ToDto()));
    }
}