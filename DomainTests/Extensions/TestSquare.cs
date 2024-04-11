using Domain.Chessboard;
using Domain.Chessboard.Pieces;

namespace DomainTests.Extensions;

public record TestSquare(string? PieceType, Color? PieceColor)
{
    public static TestSquare Empty => new(null, null);
    public static TestSquare WhiteMan => new("man", Color.White);
    public static TestSquare WhiteKing => new("king", Color.White);
    public static TestSquare BlackMan => new("man", Color.Black);
    public static TestSquare BlackKing => new("king", Color.Black);

    public static TestSquare FromSquare(SquareSnapshot snapshot)
    {
        if (snapshot.Piece is not null)
        {
            var type = snapshot.Piece.Type.ToString().ToLower();
            return new TestSquare(type, snapshot.Piece.Color);
        }

        return new TestSquare(null, null);
    }
}