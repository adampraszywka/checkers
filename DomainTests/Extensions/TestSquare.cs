using Domain;
using Domain.Pieces;

namespace DomainTests.Extensions;

public record TestSquare(string? PieceType, Color? PieceColor)
{
    public static TestSquare FromSquare(SquareSnapshot snapshot)
    {
        if (snapshot.Piece is not null)
        {
            var type = snapshot.Piece.Type.ToString().ToLower();
            return new(type, snapshot.Piece.Color);
        }
            
        return new(null, null);
    }

    public static TestSquare Empty => new(null, null);
    public static TestSquare WhiteMan => new("man", Color.White);
    public static TestSquare BlackMan => new("man", Color.Black);
}