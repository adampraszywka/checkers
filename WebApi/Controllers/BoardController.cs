using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Repository;

namespace WebApi.Controllers;

public class BoardController : Controller
{
    private readonly BoardRepository _repository;

    public BoardController(BoardRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("/board/{boardId}")]
    public async Task<IActionResult> GetBoard([FromRoute] string boardId)
    {
        var board = await _repository.Get(boardId);
        var snapshot = board.Snapshot;
    
        return new OkObjectResult(new BoardDto(snapshot));
    }

    [HttpGet("/board/{boardId}/possiblemove/{row}/{column}")]
    public async Task<IActionResult> GetPossibleMoves([FromRoute] string boardId, [FromRoute] int row, [FromRoute] int column)
    {
        var board = await _repository.Get(boardId);
        var position = new Position(row, column);

        var moves = board.PossibleMoves(position);
        if (moves.IsFailed)
        {
            return new BadRequestObjectResult(new ErrorDto(moves.Errors.First()));
        }

        return new OkObjectResult(moves.Value);
    }

    [HttpPost("/board/{boardId}/move")]
    public async Task<IActionResult> MovePiece([FromRoute] string boardId, [FromBody] MoveDto request)
    {
        var board = await _repository.Get(boardId);

        var from = new Position(request.From.Row, request.From.Column);
        var to = new Position(request.To.Row, request.To.Column);

        var result = board.Move(from, to);

        if (result.IsFailed)
        {
            return new BadRequestObjectResult(new ErrorDto(result.Errors.First()));
        }
    
        await _repository.Save(board);

        return new OkObjectResult(new BoardDto(board.Snapshot));
    }
}