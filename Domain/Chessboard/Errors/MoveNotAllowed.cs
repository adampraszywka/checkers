using FluentResults;

namespace Domain.Chessboard.Errors;

public class MoveNotAllowed() : Error("Requested move is not allowed")
{
}