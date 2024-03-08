using Domain.Pieces;

namespace Domain;

public interface Configuration
{
    public int BoardSize { get; }
    public int PlayerWhiteUpgradeRow { get; }
    public int PlayerBlackUpgradeRow { get; }
    public IEnumerable<(Piece, Position)> PiecesPositions { get; }
}

public record Position(int Row, int Column);