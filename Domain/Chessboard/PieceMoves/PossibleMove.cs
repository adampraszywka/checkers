namespace Domain.Chessboard.PieceMoves;

public record PossibleMove(Position To, IEnumerable<Position> AffectedSquares, int CapturedPieces);