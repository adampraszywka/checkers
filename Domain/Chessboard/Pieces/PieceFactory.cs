namespace Domain.Chessboard.Pieces;

public interface PieceFactory
{
    public Piece ReplacementFor(Piece piece);
}