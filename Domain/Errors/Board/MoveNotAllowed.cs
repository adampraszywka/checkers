using FluentResults;

namespace Domain.Errors.Board;

public class MoveNotAllowed() : Error("Requested move is not allowed")
{
    
}