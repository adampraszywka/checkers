using FluentResults;

namespace Domain.Chessboard.Errors;

public class PositionOutOfBoard(Position position) : Error("Requested position is out of board")
{
    public Position Position { get; } = position;
}