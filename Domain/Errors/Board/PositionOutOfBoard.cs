using FluentResults;

namespace Domain.Errors.Board;

public class PositionOutOfBoard(Position position) : Error("Requested position is out of board")
{
    public Position Position { get; } = position;
}