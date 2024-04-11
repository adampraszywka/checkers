using Domain.Chessboard;
using FluentResults;

namespace WebApi.Service.Errors;

public class PieceBelongsToTheOtherPlayer : Error
{
    public PieceBelongsToTheOtherPlayer(Position from) : base($"Cannot move piece from {from.Name}. Piece belongs to the opposite player")
    {
    }

    public PieceBelongsToTheOtherPlayer(Position from, Position to) : base($"Cannot move piece from {from.Name} to {to.Name}. Piece belongs to the opposite player")
    {
    }
}