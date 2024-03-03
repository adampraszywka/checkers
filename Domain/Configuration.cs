namespace Domain;

public interface Configuration
{
    public int BoardSize { get; }
    public IEnumerable<Func<string, (Piece, Position)>> PiecesPositions { get; }
}

public record Position(int Row, int Column);