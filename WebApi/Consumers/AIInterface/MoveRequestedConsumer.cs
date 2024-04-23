using Contracts.AiPlayers;
using MassTransit;
using WebApi.Extensions;
using WebApi.Players;
using WebApi.Service;

namespace WebApi.Consumers.AIInterface;

public class MoveRequestedConsumer(BoardService boardService, PlayerFactory playerFactory) : IConsumer<MoveRequested>
{
    public async Task Consume(ConsumeContext<MoveRequested> context)
    {
        var message = context.Message;
        
        var player = playerFactory.Create(message.Player.Id, message.Player.Type);
        var from = message.Move.From.ToPosition();
        var to = message.Move.To.ToPosition();

        var result = await boardService.Move(message.BoardId, player.Value, from, to);
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