namespace Domain.Pieces.Classic;

public class ClassicPieceFactory : PieceFactory
{
    public Piece ReplacementFor(Piece piece)
    {
        if (piece.Type != Type.Man)
        {
            throw new InvalidOperationException("Cannot upgrade piece different than Man");
        }

        return new King($"{piece.Id}K", piece.Color);
    }
}