using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Repository;

namespace WebApi.Controllers;

public class BoardController(GameRepository gameRepository, BoardRepository boardRepository) : Controller
{
    [HttpGet("/game/{gameId}/board")]
    public async Task<IActionResult> GetBoard([FromRoute] string gameId, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var game = await gameRepository.Get(gameId);
        if (game is null)
        {
            return NotFound("Game not found");
        }

        var player = new HeaderPlayer(playerId);
        var participation = game.Participation(player);
        if (!participation.DoesParticipate)
        {
            return Forbid();
        }

        var board = await boardRepository.Get(game.BoardId);
        if (board is null)
        {
            throw new NotImplementedException();
        }
        
        
        var snapshot = board.Snapshot;
    
        return new OkObjectResult(new BoardDto(snapshot));
    }

    [HttpGet("/game/{gameId}/possiblemove/{row}/{column}")]
    public async Task<IActionResult> GetPossibleMoves([FromRoute] string gameId, [FromRoute] int row, [FromRoute] int column, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var game = await gameRepository.Get(gameId);
        if (game is null)
        {
            return NotFound("Game not found");
        }

        var player = new HeaderPlayer(playerId);
        var participation = game.Participation(player);
        if (!participation.DoesParticipate)
        {
            return StatusCode(403);
        }
        
        var board = await boardRepository.Get(game.BoardId);
        if (board is null)
        {
            throw new NotImplementedException();
        }        
        
        var position = new Position(row, column);
        var piece = board.Snapshot.At(position);
        if (piece is null)
        {
            throw new NotImplementedException();
        }

        if (!participation.Participant.CanMove(piece))
        {
            return StatusCode(403);
        }
        
        var moves = board.PossibleMoves(position);
        if (moves.IsFailed)
        {
            return new BadRequestObjectResult(new ErrorDto(moves.Errors));
        }

        return new OkObjectResult(moves.Value);
    }

    [HttpPost("/game/{gameId}/move")]
    public async Task<IActionResult> MovePiece([FromRoute] string gameId, [FromBody] MoveDto request, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var game = await gameRepository.Get(gameId);
        if (game is null)
        {
            return NotFound("Game not found");
        }
        
        var player = new HeaderPlayer(playerId);
        var participation = game.Participation(player);
        if (!participation.DoesParticipate)
        {
            return StatusCode(403);
        }
        
        var board = await boardRepository.Get(gameId);

        var from = new Position(request.From.Row, request.From.Column);
        var to = new Position(request.To.Row, request.To.Column);

        var piece = board.Snapshot.At(from);
        if (piece is null)
        {
            throw new NotImplementedException();
        }
        
        if (!participation.Participant.CanMove(piece))
        {
            return StatusCode(403);
        }
        
        var result = board.Move(from, to);

        if (result.IsFailed)
        {
            return new BadRequestObjectResult(new ErrorDto(result.Errors));
        }
    
        await boardRepository.Save(board);

        return new OkObjectResult(new BoardDto(board.Snapshot));
    }
}