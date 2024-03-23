using Domain.Exceptions;
using Domain.Pieces;

namespace Domain;

public class Square
{
    private Piece? _piece = null;

    public static Square FromCoordinates(Position position)
    {
        return new($"{MapColumn(position.Column)}{position.Row + 1}", position);
    }
    
    private Square(string id, Position position)
    {
        Id = id;
        Position = position;
    }

    public string Id { get; }
    public Position Position { get; }
    public Piece Piece => _piece ?? throw new InvalidOperationException();
    public bool IsOccupied => _piece is not null;

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
    
    private static char MapColumn(int columnNumber)
    {
        const int charA = 65;
        const int charZ = 90;
        const int supportedColumns = charZ - charA;
        
        if (columnNumber > supportedColumns)
        {
            throw new ArgumentException($"Only {supportedColumns} columns are supported");
        }

        return (char) (columnNumber + charA);
    }
}