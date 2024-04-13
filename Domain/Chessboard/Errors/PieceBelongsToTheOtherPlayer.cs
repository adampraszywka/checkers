using FluentResults;

namespace Domain.Chessboard.Errors;

public class PieceBelongsToTheOtherPlayer : Error
{
    public PieceBelongsToTheOtherPlayer() : base($"Piece belongs to the opposite player")
    {
    }

    public PieceBelongsToTheOtherPlayer(Position from, Position to) : base($"Cannot move piece from {from.Name} to {to.Name}. Piece belongs to the opposite player")
    {
    }
}