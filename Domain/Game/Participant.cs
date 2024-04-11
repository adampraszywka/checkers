using Domain.Chessboard.Pieces;

namespace Domain.Game;

public record Participant(string Id, Color Color)
{
    public bool CanMove(Piece piece)
    {
        return piece.Color == Color;
    }
}