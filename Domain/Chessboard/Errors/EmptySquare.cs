using FluentResults;

namespace Domain.Chessboard.Errors;

public class EmptySquare(Position position) : Error($"Square {position.Name} is empty")
{
    public Position Position { get; } = position;
}