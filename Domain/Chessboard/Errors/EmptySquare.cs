using FluentResults;

namespace Domain.Chessboard.Errors;

public class EmptySquare(Position position) : Error($"Square ({position.Row}, {position.Column} is empty")
{
    public Position Position { get; } = position;
}