using Domain.Errors;
using FluentResults;

namespace Domain;

public class Square(string name)
{
    private Piece? _piece = null;
    
    public string Name => name;
    public SquareSnapshot Snapshot => new(Name);
    public bool IsOccupied => _piece is not null;

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
}

public record SquareSnapshot(string Name);