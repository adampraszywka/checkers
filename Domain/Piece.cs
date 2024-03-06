namespace Domain;

public interface Piece
{
    public string Id { get; }
    public Color Color { get; }
    public string Type { get; }
    
    public Square? Square { get; }
    public void Attach(Square square);
    public void Remove();

    // public IEnumerable<PossibleMove> PossibleMoves()
}

public record PossibleMove(int CapturedPieces, Square Target);

public enum Color
{
    Black, White    
}