namespace Domain.PieceMoves;

public interface PieceMove
{
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot);
}