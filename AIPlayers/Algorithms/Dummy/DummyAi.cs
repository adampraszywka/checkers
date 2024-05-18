using AIPlayers.Extensions;
using AIPlayers.MessageHub;
using Contracts.Dto;
using Microsoft.Extensions.Logging;
using Status = Contracts.AiPlayers.AiPlayerStatus;

namespace AIPlayers.Algorithms.Dummy;

public class DummyAi(ILogger<DummyAi> logger) : AIAlgorithm
{
    private readonly List<Status> _statusUpdates = new();
    
    public async Task Move(ParticipantDto participant, BoardDto board, Services services)
    {
        var color = participant.Color;
        if (color != board.CurrentPlayer)
        {
            logger.LogInformation("It's not the AI player's turn");
            return;
        }

        var squares = board.Squares.SelectMany(x => x);
        var piecesToMove = squares
            .Where(x => x.Piece is not null && x.Piece.Color == color)
            .OrderByDescending(x => x.Position.Row);
        
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
                var result = await services.MoveClient.Move(move);

                _statusUpdates.Add(Status.Command("API", $"Move from {position.ToName()} to {newPosition.ToName()}"));

                if (result.IsSuccess)
                {
                    _statusUpdates.Add(Status.Successful("API", $"Move from {position.ToName()} to {newPosition.ToName()} successful"));
                    return;
                }
                
                var error = result.Errors.First();
                _statusUpdates.Add(Status.Failed("API", $"Move from {position.ToName()} to {newPosition.ToName()} failed: {error}"));
            }
            
        }
        
        await services.StatusPublisher.Publish(_statusUpdates);
    }
    
}