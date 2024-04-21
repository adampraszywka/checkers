using Contracts.Dto;
using Contracts.Players;
using Domain.Chessboard;
using Microsoft.AspNetCore.Mvc;

using WebApi.Extensions;
using WebApi.Service;

namespace WebApi.Controllers;

public class BoardController(BoardService boardService) : Controller
{
    [HttpGet("/game/{gameId}/board")]
    public async Task<IActionResult> GetBoard([FromRoute] string gameId, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var player = new HeaderPlayer(playerId);
        var snapshotResult = await boardService.Get(gameId, player);
        if (snapshotResult.IsFailed)
        {
            // TODO: tmp solution
            return BadRequest(snapshotResult.Errors.First().Message);
        }

        return Ok(snapshotResult.Value.ToDto());
    }

    [HttpGet("/game/{gameId}/possiblemove/{row}/{column}")]
    public async Task<IActionResult> GetPossibleMoves([FromRoute] string gameId, [FromRoute] int row, [FromRoute] int column, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var player = new HeaderPlayer(playerId);
        var from = new Position(row, column);
        var possibleMovesResult = await boardService.PossibleMoves(gameId, player, from);
        if (possibleMovesResult.IsFailed)
        {
            // TODO: tmp solution
            return BadRequest(possibleMovesResult.Errors.First().Message);
        }
        
        return Ok(possibleMovesResult.Value);
    }

    [HttpPost("/game/{gameId}/move")]
    public async Task<IActionResult> MovePiece([FromRoute] string gameId, [FromBody] MoveDto request, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var player = new HeaderPlayer(playerId);
        var from = request.From.ToPosition();
        var to = request.To.ToPosition();
        
        var moveResult = await boardService.Move(gameId, player, from, to);
        if (moveResult.IsFailed)
        {
            // TODO: tmp solution
            return BadRequest(moveResult.Errors.First().Message);
        }
        
        return Ok(moveResult.Value.ToDto());
    }
}