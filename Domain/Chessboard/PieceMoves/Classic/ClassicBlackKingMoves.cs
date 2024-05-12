using Domain.Shared;

namespace Domain.Chessboard.PieceMoves.Classic;

public class ClassicBlackKingMoves : PieceMove
{
    private readonly KingMoves _kingMoves = new(Color.Black, Color.White);
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        return _kingMoves.PossibleMoves(currentPosition, boardSnapshot);
    }

    public bool UpgradeRequired(Position currentPosition) => false;
}