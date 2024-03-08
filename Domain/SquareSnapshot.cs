using Domain.Pieces;

namespace Domain;

public record SquareSnapshot
{
    public string Id { get; }
    public ObservablePiece? Piece { get; }
    
    public static SquareSnapshot Occupied(string name, ObservablePiece observablePiece) => new(name, observablePiece);
    public static SquareSnapshot Unoccupied(string name) => new(name, null);

    private SquareSnapshot(string id, ObservablePiece? piece)
    {
        Id = id;
        Piece = piece;
    }
}