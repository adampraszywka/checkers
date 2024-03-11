using Domain.PieceMoves;
using Domain.PieceMoves.Classic;
using Domain.Pieces;

namespace Domain.Configurations.Classic;

public class ClassicConfiguration : Configuration
{
    public int BoardSize => 8;
    public IEnumerable<(Piece, Position)> PiecesPositions { get; }
    public PieceMoveFactory MoveFactory { get; }

    public static ClassicConfiguration NewBoard() => new(NewGamePieces);
    public static ClassicConfiguration FromSnapshot(IEnumerable<(Piece, Position)> snapshot) => new(snapshot);
    
    private ClassicConfiguration(IEnumerable<(Piece, Position)> pieces)
    {
        PiecesPositions = pieces;
        MoveFactory = new ClassicPieceMoveFactory();
    }
    
    private static IEnumerable<(Piece, Position)> NewGamePieces 
    {
        get
        {
            // White
            yield return (new Man("A1", Color.White), new Position(Position.R1, Position.A));
            yield return (new Man("A3", Color.White), new Position(Position.R3, Position.A));
            yield return (new Man("B2", Color.White), new Position(Position.R2, Position.B));
            yield return (new Man("C1", Color.White), new Position(Position.R1, Position.C));
            yield return (new Man("C3", Color.White), new Position(Position.R3, Position.C));
            yield return (new Man("D2", Color.White), new Position(Position.R2, Position.D));
            yield return (new Man("E1", Color.White), new Position(Position.R1, Position.E));
            yield return (new Man("E3", Color.White), new Position(Position.R3, Position.E));
            yield return (new Man("F2", Color.White), new Position(Position.R2, Position.F));
            yield return (new Man("G1", Color.White), new Position(Position.R1, Position.G));
            yield return (new Man("G3", Color.White), new Position(Position.R3, Position.G));
            yield return (new Man("H2", Color.White), new Position(Position.R2, Position.H));
            
            //Black
            yield return (new Man("A7", Color.Black), new Position(Position.R7, Position.A));
            yield return (new Man("B8", Color.Black), new Position(Position.R8, Position.B));
            yield return (new Man("B6", Color.Black), new Position(Position.R6, Position.B));
            yield return (new Man("C7", Color.Black), new Position(Position.R7, Position.C));
            yield return (new Man("D8", Color.Black), new Position(Position.R8, Position.D));
            yield return (new Man("D6", Color.Black), new Position(Position.R6, Position.D));
            yield return (new Man("E7", Color.Black), new Position(Position.R7, Position.E));
            yield return (new Man("F8", Color.Black), new Position(Position.R8, Position.F));
            yield return (new Man("F6", Color.Black), new Position(Position.R6, Position.F));
            yield return (new Man("G7", Color.Black), new Position(Position.R7, Position.G));
            yield return (new Man("H8", Color.Black), new Position(Position.R8, Position.H));
            yield return (new Man("H6", Color.Black), new Position(Position.R6, Position.H));
        }
    }
}