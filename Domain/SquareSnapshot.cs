using Domain.Pieces;

namespace Domain;

public record SquareSnapshot
{
    public string Id { get; }
    public Position Position { get; }
    public Piece? Piece { get; }
    
    public static SquareSnapshot Occupied(string name, Position position, Piece observablePiece) => new(name, position, observablePiece);
    public static SquareSnapshot Unoccupied(string name, Position position) => new(name, position, null);

    private SquareSnapshot(string id, Position position, Piece? piece)
    {
        Id = id;
        Position = position;
        Piece = piece;
    }


}