using FluentResults;

namespace Domain.Errors.Board;

public class EmptySquare(Position position) : Error($"Square ({position.Row}, {position.Column} is empty")
{
    public Position Position { get; } = position;
}