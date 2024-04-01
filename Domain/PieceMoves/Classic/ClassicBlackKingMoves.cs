namespace Domain.PieceMoves.Classic;

public class ClassicBlackKingMoves : PieceMove
{
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        return Enumerable.Empty<PossibleMove>();
    }

    public bool UpdateRequired(Position currentPosition)
    {
        throw new NotImplementedException();
    }
}