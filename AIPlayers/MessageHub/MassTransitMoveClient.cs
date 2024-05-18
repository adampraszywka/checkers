using AIPlayers.Extensions;
using Contracts.AiPlayers;
using Contracts.Dto;
using FluentResults;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AIPlayers.MessageHub;

public class MassTransitMoveClient(IRequestClient<MoveRequested> client, ILogger<MassTransitMoveClient> logger, string boardId, string playerId) : MoveClient
{
    public async Task<Result> Move(MoveDto move)
    {
        var e = new MoveRequested(boardId, playerId, move);
        var response = await client.GetResponse<MoveSucceeded, MoveFailed>(e);
        
        if (response.Is<MoveSucceeded>(out _))
        {
            logger.LogInformation(
                "AI player {PlayerId} moved piece on board {BoardId} from {Position} to {NewPosition}", 
                playerId, 
                boardId,
                move.From.ToName(),
                move.To.ToName());
            return Result.Ok();
        }

        if (response.Is<MoveFailed>(out var moveFailed))
        {
            logger.LogWarning("AI player {PlayerId} failed to move piece on board {BoardId} from {Position} to {NewPosition}. Reason: {Reason}",
                playerId,
                boardId,
                move.From.ToName(),
                move.To.ToName(),
                string.Join(", ", moveFailed.Message.ErrorMessages));
            return Result.Fail(new AiAlgorithmMoveFailed(moveFailed.Message.ErrorMessages));
        }
        
        return Result.Fail("Unknown response from API");
    }
}