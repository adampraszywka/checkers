namespace Domain.PieceMoves;

public interface PieceMove
{
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot);
    public bool UpgradeRequired(Position currentPosition);
}