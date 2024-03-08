using Domain.Pieces;

namespace Domain.Configurations;

public class Checkers8X8 : Configuration
{
    public int BoardSize => 8;
    public int PlayerWhiteUpgradeRow => Position.R8;
    public int PlayerBlackUpgradeRow => Position.R1;

    public IEnumerable<(Piece, Position)> PiecesPositions
    {
        get
        {
            // White
            yield return (new Man("A1", Color.White), new Position(Position.R1, Position.A));
            yield return (new Man("B2", Color.White), new Position(Position.R2, Position.B));
            yield return (new Man("C1", Color.White), new Position(Position.R1, Position.C));
            yield return (new Man("D2", Color.White), new Position(Position.R2, Position.D));
            yield return (new Man("E1", Color.White), new Position(Position.R1, Position.E));
            yield return (new Man("F2", Color.White), new Position(Position.R2, Position.F));
            yield return (new Man("G1", Color.White), new Position(Position.R1, Position.G));
            yield return (new Man("H2", Color.White), new Position(Position.R2, Position.H));
            
            //Black
            yield return (new Man("A7", Color.Black), new Position(Position.R7, Position.A));
            yield return (new Man("B8", Color.Black), new Position(Position.R8, Position.B));
            yield return (new Man("C7", Color.Black), new Position(Position.R7, Position.C));
            yield return (new Man("D8", Color.Black), new Position(Position.R8, Position.D));
            yield return (new Man("E7", Color.Black), new Position(Position.R7, Position.E));
            yield return (new Man("F8", Color.Black), new Position(Position.R8, Position.F));
            yield return (new Man("G7", Color.Black), new Position(Position.R7, Position.G));
            yield return (new Man("H8", Color.Black), new Position(Position.R8, Position.H));
        }
    }
}