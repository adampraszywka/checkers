using Domain.Pieces;

namespace Domain.Configurations;

public class Checkers8X8 : Configuration
{
    private const int A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7;
    private const int R1 = 0, R2 = 1, R7 = 6, R8 = 7;
    
    public int BoardSize => 8;
    public int PlayerWhiteUpgradeRow => R8;
    public int PlayerBlackUpgradeRow => R1;

    public IEnumerable<(Piece, Position)> PiecesPositions
    {
        get
        {
            // White
            yield return (new Man("A1", Color.White), new Position(R1, A));
            yield return (new Man("B2", Color.White), new Position(R2, B));
            yield return (new Man("C1", Color.White), new Position(R1, C));
            yield return (new Man("D2", Color.White), new Position(R2, D));
            yield return (new Man("E1", Color.White), new Position(R1, E));
            yield return (new Man("F2", Color.White), new Position(R2, F));
            yield return (new Man("G1", Color.White), new Position(R1, G));
            yield return (new Man("H2", Color.White), new Position(R2, H));
            
            //Black
            yield return (new Man("A7", Color.Black), new Position(R7, A));
            yield return (new Man("B8", Color.Black), new Position(R8, B));
            yield return (new Man("C7", Color.Black), new Position(R7, C));
            yield return (new Man("D8", Color.Black), new Position(R8, D));
            yield return (new Man("E7", Color.Black), new Position(R7, E));
            yield return (new Man("F8", Color.Black), new Position(R8, F));
            yield return (new Man("G7", Color.Black), new Position(R7, G));
            yield return (new Man("H8", Color.Black), new Position(R8, H));
        }
    }
}