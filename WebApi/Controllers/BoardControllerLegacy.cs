using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Dto.Response;
using WebApi.Extensions;
using WebApi.Players;

namespace WebApi.Controllers;

public class BoardControllerLegacy(BoardRepository repository) : Controller
{
    private const string WhitePlayerId = "whitey";
    private const string BlackPlayerId = "blackie";

    [HttpGet("/board/{boardId}")]
    public async Task<IActionResult> GetBoard([FromRoute] string boardId)
    {
        var board = await repository.Get(boardId) ?? CreateBoard(boardId);
        
        return new OkObjectResult(board.ToDto());
    }

    [HttpGet("/board/{boardId}/possiblemove/{row}/{column}")]
    public async Task<IActionResult> GetPossibleMoves([FromRoute] string boardId, [FromRoute] int row,
        [FromRoute] int column)
    {
        var board = await repository.Get(boardId) ?? CreateBoard(boardId);
        var position = new Position(row, column);

        var player = DummyPlayer(board.Snapshot, position);
        var moves = board.PossibleMoves(player, position);
        if (moves.IsFailed)
        {
            return new BadRequestObjectResult(new ErrorDto(moves.Errors));
        }

        return new OkObjectResult(moves.Value);
    }

    [HttpPost("/board/{boardId}/move")]
    public async Task<IActionResult> MovePiece([FromRoute] string boardId, [FromBody] MoveDto request)
    {
        var board = await repository.Get(boardId) ?? CreateBoard(boardId);

        var from = new Position(request.From.Row, request.From.Column);
        var to = new Position(request.To.Row, request.To.Column);

        var player = DummyPlayer(board.Snapshot, from);
        var result = board.Move(player, from, to);

        if (result.IsFailed)
        {
            return new BadRequestObjectResult(new ErrorDto(result.Errors));
        }

        await repository.Save(board);

        return new OkObjectResult(board.ToDto());
    }

    // Even more hacks to be compatible with old UI :)
    private GameBoard CreateBoard(string id)
    {
        // Compatibility with old UI
        var participants = new List<Participant>
        {
            new(new HeaderPlayer(WhitePlayerId), Color.White), new(new HeaderPlayer(BlackPlayerId), Color.Black)
        };
        var board = new GameBoard(id, ClassicConfiguration.NewBoard(), participants);
        repository.Save(board);
        return board;
    }

    // More and more...
    private Player DummyPlayer(BoardSnapshot snapshot, Position position)
    {
        var piece = snapshot.At(position);
        if (piece is null)
        {
            return new HeaderPlayer(WhitePlayerId);
        }

        return piece.Color == Color.White ? new HeaderPlayer(WhitePlayerId) : new HeaderPlayer(BlackPlayerId);
    }
}