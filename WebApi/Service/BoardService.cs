using Contracts.Notification;
using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;
using Domain.Shared;
using FluentResults;
using MassTransit;
using WebApi.Extensions;
using WebApi.Service.Errors;

namespace WebApi.Service;

public class BoardService(BoardRepository boardRepository, IPublishEndpoint publishEndpoint)
{
    public async Task<Result<Board>> Get(string boardId, Player player)
    {
        var boardResult = await GetBoard(boardId, player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }

        var board = boardResult.Value;
        return Result.Ok(board);
    }

    public async Task<Result<IEnumerable<PossibleMove>>> PossibleMoves(string boardId, Player player, Position position)
    {
        var boardResult = await GetBoard(boardId, player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }
    
        var board = boardResult.Value;
        var moves = board.PossibleMoves(player, position);
        if (moves.IsFailed)
        {
            return Result.Fail(new BoardPossibleMovesUnavailable(moves.Errors));
        }

        return Result.Ok(moves.Value);
    }

    public async Task<Result<Board>> Move(string boardId, Player player, Position from, Position to)
    {
        var boardResult = await GetBoard(boardId, player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }

        var board = boardResult.Value;
        var result = board.Move(player, from, to);
        if (result.IsFailed)
        {
            return Result.Fail(new BoardMoveFailed(result.Errors));
        }

        await boardRepository.Save(board);

        var notification = new BoardUpdated(board.ToDto(), board.Participants.List.ToDto());
        await publishEndpoint.Publish(notification);
        
        return Result.Ok(board); 
    }
    
    private async Task<Result<Board>> GetBoard(string boardId, Player player)
    {
        var board = await boardRepository.Get(boardId);
        if (board is null)
        {
            return Result.Fail(new BoardNotFound(boardId));    
        }

        var participant = board.Participants.For(player);
        if (participant is null)
        {
            return Result.Fail(new BoardNoAccess(player, boardId));
        }

        return Result.Ok(board);
    }
}