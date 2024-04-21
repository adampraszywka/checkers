using AIPlayers.Extensions;
using Contracts.AiPlayers;
using Contracts.Dto;
using Contracts.Players;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AIPlayers.Players.Dummy;

public class AiDummyPlayerConsumer(
    IRequestClient<MoveRequested> moveClient, 
    ILogger<AiDummyPlayerConsumer> logger) : IConsumer<DummyPlayerGameProgressChanged>
{
    public async Task Consume(ConsumeContext<DummyPlayerGameProgressChanged> context)
    {
        var message = context.Message;
        var board = message.Board;
        var playerId = message.Participant.Id;
        var color = message.Participant.Color;
        
        if (color != board.CurrentPlayer)
        {
            logger.LogInformation("It's not the AI player's turn");
            return;
        }

        var squares = board.Squares.SelectMany(x => x);
        var piecesToMove = squares
            .Where(x => x.Piece is not null && x.Piece.Color == color)
            .OrderByDescending(x => x.Position.Row);
        
        var player = new PlayerDto(playerId, AIDummyPlayer.TypeValue);


        foreach (var piece in piecesToMove)
        {
            var position = piece.Position;

            var options = new List<PositionDto>
            {
                new(position.Row - 1, position.Column - 1), // left
                new(position.Row - 1, position.Column + 1) // right
            };
            
            foreach (var newPosition in options)
            {
                // Try to the left
                var move = new MoveDto(position, newPosition);

                var e = new MoveRequested(board.Id, player, move);
                var response = await moveClient.GetResponse<MoveSucceeded, MoveFailed>(e);
        
                if (response.Is<MoveSucceeded>(out _))
                {
                    logger.LogInformation(
                        "AI player {PlayerId} moved piece on board {BoardId} from {Position} to {NewPosition}", 
                        playerId, 
                        board.Id,
                        position.ToCoordinates(),
                        newPosition.ToCoordinates());
                    return;
                }

                if (response.Is<MoveFailed>(out var moveFailed))
                {
                    logger.LogWarning("AI player {PlayerId} failed to move piece on board {BoardId} from {Position} to {NewPosition}. Reason: {Reason}",
                        playerId,
                        board.Id,
                        position.ToCoordinates(),
                        newPosition.ToCoordinates(),
                        moveFailed.Message.ErrorMessages.First());        
                }
            }
            
        }
        
     
        
        

    }
}