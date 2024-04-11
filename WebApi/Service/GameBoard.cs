using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;
using Domain.Game;
using Domain.Repository;
using FluentResults;
using WebApi.Service.Errors;

namespace WebApi.Service;

public class GameBoard 
{
    private readonly GameRepository _gameRepository;
    private readonly BoardRepository _boardRepository;
    private readonly string _gameId;

    public GameBoard(GameRepository gameRepository, BoardRepository boardRepository, string gameId)
    {
        _gameRepository = gameRepository;
        _boardRepository = boardRepository;
        _gameId = gameId;
    }
    
    public async Task<Result<BoardSnapshot>> Get(Player player)
    {
        var boardResult = await GetBoard(player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }

        var (board, _) = boardResult.Value;
        return Result.Ok(board.Snapshot);
    }

    public async Task<Result<IEnumerable<PossibleMove>>> PossibleMoves(Player player, Position position)
    {
        var boardResult = await GetBoard(player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }
    
        var (board, participation) = boardResult.Value;
    
        var piece = board.Snapshot.At(position);
        if (piece is null)
        {
            return Result.Fail(new EmptySquare(position));
        }
        
        if (!participation.Participant.CanMove(piece))
        {
            return Result.Fail(new PieceBelongsToTheOtherPlayer(position));
        }
    
        var moves = board.PossibleMoves(position);
        if (moves.IsFailed)
        {
            return Result.Fail(new PossibleMovesUnavailable(moves.Errors));
        }

        return Result.Ok(moves.Value);
    }

    public async Task<Result<BoardSnapshot>> Move(Player player, Position from, Position to)
    {
        var boardResult = await GetBoard(player);
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors); 
        }
    
        var (board, participation) = boardResult.Value;
        var piece = board.Snapshot.At(from);
        if (piece is null)
        {
            return Result.Fail(new EmptySquare(from));
        }

        if (!participation.Participant.CanMove(piece))
        {
            return Result.Fail(new PieceBelongsToTheOtherPlayer(from, to));
        }

        var result = board.Move(from, to);
        if (result.IsFailed)
        {
            return Result.Fail(new MoveFailed(result.Errors));
        }

        await _boardRepository.Save(board);

        return Result.Ok(board.Snapshot); 
    }
    
    private async Task<Result<(Board Board, Participation participation)>> GetBoard(Player player)
    {
        var game = await _gameRepository.Get(_gameId);
        if (game is null)
        {
            return Result.Fail(new GameNotFound(_gameId));
        }

        var participation = game.Participation(player);
        if (!participation.DoesParticipate)
        {
            return Result.Fail(new PlayerDoesNotParticipate(player));
        }

        var board = await _boardRepository.Get(game.BoardId);
        if (board is null)
        {
            return Result.Fail(new BoardNotFound(game.BoardId));    
        }

        return Result.Ok((board, participation));
    }
}