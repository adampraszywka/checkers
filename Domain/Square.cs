using Domain.Exceptions;
using Domain.Pieces;

namespace Domain;

public class Square
{
    private Piece? _piece = null;

    public static Square FromCoordinates(int row, int column)
    {
        return new($"{MapColumn(column)}{row + 1}", row, column);
    }
    
    private Square(string id, int row, int column)
    {
        Id = id;
        Row = row;
        Column = column;
    }

    public string Id { get; }
    public int Column { get; }
    public int Row { get; }
    public Position Position => new(Row, Column);
   
    public bool IsOccupied => _piece is not null;

    public SquareSnapshot Snapshot()
    {
        if (IsOccupied)
        {
            return SquareSnapshot.Occupied(Id, _piece!);
        }

        return SquareSnapshot.Unoccupied(Id);
    }
    
    public void Move(Piece piece)
    {
        if (_piece is not null)
        {
            throw InvalidBoardState.SquareIsNotEmpty;
        }
        
        piece.Attach(this);
        _piece = piece;
    }

    public void RemovePiece()
    {
        if (_piece is null)
        {
            throw InvalidBoardState.SquareIsEmpty;
        }

        _piece.Remove();
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