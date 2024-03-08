using FluentResults;

namespace Domain.Errors.Board;

public class PieceNotFound(string pieceId) : Error($"Piece {pieceId} not found on the board")
{
    public string PieceId { get; } = pieceId;
}