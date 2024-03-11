using Domain.Pieces;
using Type = Domain.Pieces.Type;

namespace Domain.PieceMoves.Classic;

public class ClassicPieceMoveFactory : PieceMoveFactory
{
    public PieceMove For(Piece piece)
    {
        if (piece.Type is Type.Man)
        {
            return piece.Color is Color.White ? new ClassicWhiteManMoves() : new ClassicBlackManMoves();
        }

        if (piece.Type is Type.King)
        {
            return piece.Color is Color.White ? new ClassicWhiteKingMoves() : new ClassicBlackKingMoves();
        }

        throw new InvalidOperationException();
    }
}