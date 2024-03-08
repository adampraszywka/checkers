namespace Domain.Pieces;

public interface ObservablePiece
{
    public string Id { get; }
    public Color Color { get; }
    public string Type { get; }
    
    // public IEnumerable<PossibleMove> PossibleMoves()
}

public record PossibleMove(int CapturedPieces, Square Target);