using Domain.Pieces;

namespace Domain.Configurations;

public class Checkers8X8 : Configuration
{
    public int BoardSize => 8;

    public IEnumerable<Func<string, (Piece, Position)>> PiecesPositions
    {
        get
        {
            yield return id => (new Man(id, Color.White), new Position(0, 0));
        }
    }
}