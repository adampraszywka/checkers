using Domain.Pieces;

namespace Domain;

public record Participant(string Id, Color Color)
{
    public bool CanMove(Piece piece) => piece.Color == Color;
}