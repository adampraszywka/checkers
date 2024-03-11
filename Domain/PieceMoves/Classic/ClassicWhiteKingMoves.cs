namespace Domain.PieceMoves.Classic;

public class ClassicWhiteKingMoves : PieceMove
{
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        return Enumerable.Empty<Move>();
    }
}