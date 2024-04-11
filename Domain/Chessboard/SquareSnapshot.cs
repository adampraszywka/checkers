using Domain.Chessboard.Pieces;

namespace Domain.Chessboard;

public record SquareSnapshot
{
    private SquareSnapshot(string id, Position position, Piece? piece)
    {
        Id = id;
        Position = position;
        Piece = piece;
    }

    public string Id { get; }
    public Position Position { get; }
    public Piece? Piece { get; }

    public static SquareSnapshot Occupied(string name, Position position, Piece observablePiece)
    {
        return new SquareSnapshot(name, position, observablePiece);
    }

    public static SquareSnapshot Unoccupied(string name, Position position)
    {
        return new SquareSnapshot(name, position, null);
    }
}