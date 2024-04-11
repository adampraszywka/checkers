using Domain.Chessboard.Exceptions;
using Domain.Chessboard.Pieces;

namespace Domain.Chessboard;

public class Square
{
    private Piece? _piece;

    private Square(string id, Position position)
    {
        Id = id;
        Position = position;
    }

    public string Id { get; }
    public Position Position { get; }
    public Piece Piece => _piece ?? throw new InvalidOperationException();
    public bool IsOccupied => _piece is not null;

    public static Square FromCoordinates(Position position)
    {
        if (position.Column >= 26)
            throw new ArgumentException($"Only A-Z columns are supported");
        
        return new Square(position.Name, position);
    }

    public SquareSnapshot Snapshot()
    {
        if (IsOccupied)
        {
            return SquareSnapshot.Occupied(Id, Position, _piece!);
        }

        return SquareSnapshot.Unoccupied(Id, Position);
    }

    public void Move(Piece piece)
    {
        if (_piece is not null)
        {
            throw InvalidBoardState.SquareIsNotEmpty;
        }

        _piece = piece;
    }

    public void RemovePiece()
    {
        if (_piece is null)
        {
            throw InvalidBoardState.SquareIsEmpty;
        }

        _piece = null;
    }
}