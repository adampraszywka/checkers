using Domain.Chessboard;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Dto.Response;
using WebApi.Players;
using WebApi.Service;

namespace WebApi.Controllers;

public class BoardController(GameBoardFactory factory) : Controller
{
    [HttpGet("/game/{gameId}/board")]
    public async Task<IActionResult> GetBoard([FromRoute] string gameId, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var gameBoard = factory.Create(gameId);

        var player = new HeaderPlayer(playerId);
        var snapshotResult = await gameBoard.Get(player);
        if (snapshotResult.IsFailed)
        {
            // TODO: tmp solution
            return BadRequest(snapshotResult.Errors.First().Message);
        }

        var dto = new BoardDto(snapshotResult.Value);
        return Ok(dto);
    }

    [HttpGet("/game/{gameId}/possiblemove/{row}/{column}")]
    public async Task<IActionResult> GetPossibleMoves([FromRoute] string gameId, [FromRoute] int row, [FromRoute] int column, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var gameBoard = factory.Create(gameId);

        var player = new HeaderPlayer(playerId);
        var from = new Position(row, column);
        var possibleMovesResult = await gameBoard.PossibleMoves(player, from);
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
        var gameBoard = factory.Create(gameId);
        
        var player = new HeaderPlayer(playerId);
        var from = request.From.Position;
        var to = request.To.Position;
        
        var moveResult = await gameBoard.Move(player, from, to);
        if (moveResult.IsFailed)
        {
            // TODO: tmp solution
            return BadRequest(moveResult.Errors.First().Message);
        }

        var dto = new BoardDto(moveResult.Value);
        return Ok(dto);
    }
}