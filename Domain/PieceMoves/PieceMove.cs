namespace Domain.PieceMoves;

public interface PieceMove
{
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot);
    public bool UpdateRequired(Position currentPosition);
}