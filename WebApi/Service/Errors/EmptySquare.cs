using Domain.Chessboard;
using FluentResults;

namespace WebApi.Service.Errors;

public class EmptySquare(Position position): Error($"Square {position.Name} is empty")
{
    public Position Position { get; } = position;
}