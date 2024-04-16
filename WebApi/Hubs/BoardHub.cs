using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;
using Microsoft.AspNetCore.SignalR;
using WebApi.Dto;
using WebApi.Dto.Response;
using WebApi.Extensions;
using WebApi.Hubs.Extensions;
using WebApi.Service;

namespace WebApi.Hubs;

public class BoardHub(BoardService boardService, ILogger<BoardHub> logger) : Hub<BoardHubClient>
{
    public override async Task OnConnectedAsync()
    {
        var player = Context.Player();
        var boardId = Context.BoardId();
        
        if (player is null || boardId is null)
        {
            throw new NotImplementedException();
        }
        
        var boardResult = await boardService.Get(boardId, player);
        if (boardResult.IsFailed)
        {
            throw new NotImplementedException();
        }

        var board = boardResult.Value;
        var groupName = board.Id;
        var connectionId = Context.ConnectionId;
        
        await Groups.AddToGroupAsync(connectionId, groupName);
        await Clients.Caller.BoardUpdated(board.ToDto());
    }
    
    public async Task<ActionResult<BoardDto>> Move(MoveDto move)
    {
        var player = Context.Player();
        var boardId = Context.BoardId();

        if (player is null || boardId is null)
        {
            return AuthError<BoardDto>();
        }
        
        var boardResult = await boardService.Move(boardId, player, move.From.Position, move.To.Position);
        if (boardResult.IsFailed)
        {
            return ActionResult<BoardDto>.FromErrors(boardResult.Errors);
        }

        var board = boardResult.Value;
        return ActionResult<BoardDto>.Success(board.ToDto());
    }

    public async Task<ActionResult<IEnumerable<PossibleMove>>> PossibleMoves(PositionDto from)
    {
        var player = Context.Player();
        var boardId = Context.BoardId();

        if (player is null || boardId is null)
        {
            return AuthError<IEnumerable<PossibleMove>>();
        }
        
        var possibleMovesResult = await boardService.PossibleMoves(boardId, player, from.Position);
        if (possibleMovesResult.IsFailed)
        {
            return ActionResult<IEnumerable<PossibleMove>>.FromErrors(possibleMovesResult.Errors);
        }

        var possibleMoves = possibleMovesResult.Value;
        return ActionResult<IEnumerable<PossibleMove>>.Success(possibleMoves);
    }
    
    private static ActionResult<T> AuthError<T>() where T : class
    {
        return ActionResult<T>.Failed("Authorization error!");
    }
}