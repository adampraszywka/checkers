using Domain.Configurations;
using Domain.Errors.Board;
using Domain.Exceptions;
using Domain.PieceMoves;
using Domain.Pieces;
using Extension;
using FluentResults;

namespace Domain;

public class Board
{
    private readonly BoardSize _boardSize;
    private readonly PieceMoveFactory _pieceMoveFactory;
    
    private readonly Square[,] _squares;
    private readonly List<Piece> _pieces;
    
    public BoardSnapshot Snapshot => GenerateSnapshot();
    
    public Board(Configuration configuration)
    {
        _boardSize = configuration.BoardSize;
        _pieceMoveFactory = configuration.MoveFactory;
        
        _squares = new Square[_boardSize.Rows, _boardSize.Columns];
        _pieces = new List<Piece>();
        
        for (var row = 0; row < _boardSize.Rows; row++)
        {
            for (var column = 0; column < _boardSize.Columns; column++)
            {
                _squares[row, column] = Square.FromCoordinates(row, column);
            }
        }

        foreach (var (piece, position) in configuration.PiecesPositions)
        {
            if (!position.IsWithinBoard(_boardSize))
            {
                //TODO: Catch an error and throw it in exception?
                throw new NotImplementedException();
            }
            
            var square = _squares[position.Row, position.Column];
            square.Move(piece);
            
            _pieces.Add(piece);
        }
    }

    public Result Move(Position source, Position target)
    {
        if (!source.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(source));
        }
        
        if (!target.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(target));
        }
        
        var square = _squares[source.Row, source.Column];
        if (!square.IsOccupied)
        {
            return Result.Fail(new EmptySquare(source));
        }

        var piece = square.Piece;
        var pieceMove = _pieceMoveFactory.For(piece);

        var possibleMoves = pieceMove.PossibleMoves(square.Position, Snapshot);
        var move = possibleMoves.FirstOrDefault(x => x.To == target);

        if (move is null)
        {
            return Result.Fail(new MoveNotAllowed());
        }

        foreach (var affectedSquare in move.AffectedSquares)
        {
            // capture if necessary
        }
        
        var newSquare = _squares[target.Row, target.Column];

        square.RemovePiece();
        newSquare.Move(piece);

        return Result.Ok();
    }
    
    private BoardSnapshot GenerateSnapshot() => new(_boardSize, _squares.Transform(s => s.Snapshot()));
}