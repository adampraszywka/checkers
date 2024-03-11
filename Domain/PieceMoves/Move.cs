namespace Domain.PieceMoves;

public record Move(Position To, IEnumerable<Position> AffectedSquares, int CapturedPieces);