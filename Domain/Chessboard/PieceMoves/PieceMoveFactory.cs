using Domain.Chessboard.Pieces;

namespace Domain.Chessboard.PieceMoves;

public interface PieceMoveFactory
{
    public PieceMove For(Piece piece);
}