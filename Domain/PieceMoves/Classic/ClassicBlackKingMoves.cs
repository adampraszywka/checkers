namespace Domain.PieceMoves.Classic;

public class ClassicBlackKingMoves : PieceMove
{
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        return Enumerable.Empty<PossibleMove>();
    }

    public bool UpgradeRequired(Position currentPosition)
    {
        throw new NotImplementedException();
    }
}