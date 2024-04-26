using AIPlayers.Extensions;
using Contracts.AiPlayers;
using Contracts.Dto;
using Contracts.Players;
using MassTransit;
using Microsoft.Extensions.Logging;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Players.Dummy;

public class AiDummyPlayerConsumer(
    IRequestClient<MoveRequested> moveClient, 
    IPublishEndpoint publishEndpoint,
    ILogger<AiDummyPlayerConsumer> logger) : IConsumer<DummyPlayerGameProgressChanged>
{
    private readonly List<Status> _statusUpdates = new();
    
    public async Task Consume(ConsumeContext<DummyPlayerGameProgressChanged> context)
    {
        await HandleMessage(context);
        await SendStatusNotification(context.Message.Board.Id);
    }

    private async Task HandleMessage(ConsumeContext<DummyPlayerGameProgressChanged> context)
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

                _statusUpdates.Add(Status.Command("API", $"Move from {position.ToCoordinates()} to {newPosition.ToCoordinates()}"));
                
                if (response.Is<MoveSucceeded>(out _))
                {
                    _statusUpdates.Add(Status.Successful("API", $"Move from {position.ToCoordinates()} to {newPosition.ToCoordinates()} successful"));
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
                    _statusUpdates.Add(Status.Failed("API", $"Move from {position.ToCoordinates()} to {newPosition.ToCoordinates()} failed: {moveFailed.Message.ErrorMessages.First()}"));
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

    private async Task SendStatusNotification(string boardId)
    {
        await publishEndpoint.Publish(new AiPlayerStatusUpdated(boardId, _statusUpdates));
    }
}