using Domain.Configurations;
using Domain.Errors.Board;
using Domain.Exceptions;
using Domain.Pieces;
using Extension;
using FluentResults;

namespace Domain;

public class Board
{
    private readonly int _boardSize;
    
    private readonly Square[,] _squares;
    private readonly List<Piece> _pieces;
    
    public BoardSnapshot Snapshot => GenerateSnapshot();
    
    public Board(Configuration configuration)
    {
        _boardSize = configuration.BoardSize;
        _squares = new Square[_boardSize, _boardSize];
        _pieces = new List<Piece>();
        
        for (var row = 0; row < _boardSize; row++)
        {
            for (var column = 0; column < _boardSize; column++)
            {
                _squares[row, column] = Square.FromCoordinates(row, column);
            }
        }

        foreach (var (piece, position) in configuration.PiecesPositions)
        {
            if (position.Column > _boardSize || position.Row > _boardSize)
            {
                //TODO: Catch an error and throw it in exception?
                throw new NotImplementedException();
            }
            
            var square = _squares[position.Row, position.Column];
            square.Move(piece);
            
            _pieces.Add(piece);
        }
    }

    public Result Move(string pieceId, Position position)
    {
        if (!position.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(position));
        }
        
        var piece = _pieces.FirstOrDefault(x => x.Id == pieceId);
        if (piece is null)
        {
            return Result.Fail(new PieceNotFound(pieceId));
        }

        var square = piece.Square;
        if (square is null)
        {
            throw InvalidBoardState.BrokenPieceSquareConnection;
        }

        var newSquare = _squares[position.Row, position.Column];

        square.RemovePiece();
        newSquare.Move(piece);

        return Result.Ok();
    }
    
    private BoardSnapshot GenerateSnapshot() => new(_squares.Transform(s => s.Snapshot()));
}