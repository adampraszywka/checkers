using Domain.Pieces;

namespace Domain.PieceMoves;

public interface PieceMoveFactory
{
    public PieceMove For(Piece piece);
}