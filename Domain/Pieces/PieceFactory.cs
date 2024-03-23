namespace Domain.Pieces;

public interface PieceFactory
{
    public Piece ReplacementFor(Piece piece);
}