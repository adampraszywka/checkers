namespace Domain.Chessboard.PieceMoves.Classic;

public class ClassicWhiteKingMoves : PieceMove
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