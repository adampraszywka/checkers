using Domain.Errors;
using FluentResults;

namespace Domain;

public class Square
{
    private Piece? _piece = null;
    private readonly string _id;

    public static Square FromCoordinates(int row, int column)
    {
        return new($"{MapColumn(column)}{row + 1}");
    }
    
    private Square(string id)
    {
        _id = id;
    }

    public string Id => _id;
   
    public bool IsOccupied => _piece is not null;

    public SquareSnapshot Snapshot()
    {
        if (IsOccupied)
        {
            return SquareSnapshot.Occupied(Id, _piece!);
        }

        return SquareSnapshot.Unoccupied(Id);
    }
    
    public Result Move(Piece piece)
    {
        if (_piece is not null)
        {
            return Result.Fail(new SquareOccupied());
        }
        
        _piece = piece;
        return Result.Ok();
    }

    public Result RemovePiece()
    {
        if (_piece is null)
        {
            return Result.Fail(new SquareEmpty());
        }

        _piece = null;
        return Result.Ok();
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