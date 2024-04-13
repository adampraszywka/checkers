using Domain.Chessboard.Pieces;
using Domain.Shared;
using Type = Domain.Chessboard.Pieces.Type;

namespace Domain.Chessboard.PieceMoves.Classic;

public class ClassicPieceMoveFactory : PieceMoveFactory
{
    public PieceMove For(Piece piece)
    {
        if (piece.Type is Type.Man)
            return piece.Color is Color.White ? new ClassicWhiteManMoves() : new ClassicBlackManMoves();

        if (piece.Type is Type.King)
            return piece.Color is Color.White ? new ClassicWhiteKingMoves() : new ClassicBlackKingMoves();

        throw new InvalidOperationException();
    }
}