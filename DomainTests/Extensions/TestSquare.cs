using Domain;
using Domain.Pieces;

namespace DomainTests.Extensions;

public record TestSquare(string? PieceType, Color? PieceColor)
{
    public static TestSquare FromSquare(SquareSnapshot snapshot)
    {
        if (snapshot.Piece is not null)
        {
            return new(snapshot.Piece.Type, snapshot.Piece.Color);
        }
            
        return new(null, null);
    }

    public static TestSquare Empty => new(null, null);
    public static TestSquare WhiteMan => new("man", Color.White);
    public static TestSquare BlackMan => new("man", Color.Black);
}