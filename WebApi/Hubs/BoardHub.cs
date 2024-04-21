using Contracts.Dto;
using Domain.Chessboard.PieceMoves;
using Microsoft.AspNetCore.SignalR;
using WebApi.Dto;
using WebApi.Dto.Response;
using WebApi.Extensions;
using WebApi.Hubs.Extensions;
using WebApi.Results;
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
    
    public async Task<NullableActionResult<BoardDto>> Move(MoveDto move)
    {
        var player = Context.Player();
        var boardId = Context.BoardId();

        if (player is null || boardId is null)
        {
            return AuthError<BoardDto>();
        }

        var from = move.From.ToPosition();
        var to = move.To.ToPosition();
        var boardResult = await boardService.Move(boardId, player, from, to);
        if (boardResult.IsFailed)
        {
            return NullableActionResult<BoardDto>.FromErrors(boardResult.Errors);
        }

        var board = boardResult.Value;
        return NullableActionResult<BoardDto>.Success(board.ToDto());
    }

    public async Task<NullableActionResult<IEnumerable<PossibleMove>>> PossibleMoves(PositionDto from)
    {
        var player = Context.Player();
        var boardId = Context.BoardId();

        if (player is null || boardId is null)
        {
            return AuthError<IEnumerable<PossibleMove>>();
        }

        var position = from.ToPosition();
        var possibleMovesResult = await boardService.PossibleMoves(boardId, player, position);
        if (possibleMovesResult.IsFailed)
        {
            return NullableActionResult<IEnumerable<PossibleMove>>.FromErrors(possibleMovesResult.Errors);
        }

        var possibleMoves = possibleMovesResult.Value;
        return NullableActionResult<IEnumerable<PossibleMove>>.Success(possibleMoves);
    }
    
    private static NullableActionResult<T> AuthError<T>() where T : class
    {
        return NullableActionResult<T>.Failed("Authorization error!");
    }
}