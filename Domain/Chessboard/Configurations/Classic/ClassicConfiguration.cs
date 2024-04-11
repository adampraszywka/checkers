using Domain.Chessboard.GameStates;
using Domain.Chessboard.PieceMoves;
using Domain.Chessboard.PieceMoves.Classic;
using Domain.Chessboard.Pieces;
using Domain.Chessboard.Pieces.Classic;

namespace Domain.Chessboard.Configurations.Classic;

public class ClassicConfiguration : Configuration
{
    private ClassicConfiguration(IEnumerable<(Piece, Position)> pieces, ClassicGameState gameState)
    {
        PiecesPositions = pieces;
        MoveFactory = new ClassicPieceMoveFactory();
        PieceFactory = new ClassicPieceFactory();
        GameState = gameState;
    }

    private static IEnumerable<(Piece, Position)> NewGamePieces
    {
        get
        {
            // White
            yield return (new Man("A1", Color.White), Position.A1);
            yield return (new Man("A3", Color.White), Position.A3);
            yield return (new Man("B2", Color.White), Position.B2);
            yield return (new Man("C1", Color.White), Position.C1);
            yield return (new Man("C3", Color.White), Position.C3);
            yield return (new Man("D2", Color.White), Position.D2);
            yield return (new Man("E1", Color.White), Position.E1);
            yield return (new Man("E3", Color.White), Position.E3);
            yield return (new Man("F2", Color.White), Position.F2);
            yield return (new Man("G1", Color.White), Position.G1);
            yield return (new Man("G3", Color.White), Position.G3);
            yield return (new Man("H2", Color.White), Position.H2);

            //Black
            yield return (new Man("A7", Color.Black), Position.A7);
            yield return (new Man("B8", Color.Black), Position.B8);
            yield return (new Man("B6", Color.Black), Position.B6);
            yield return (new Man("C7", Color.Black), Position.C7);
            yield return (new Man("D8", Color.Black), Position.D8);
            yield return (new Man("D6", Color.Black), Position.D6);
            yield return (new Man("E7", Color.Black), Position.E7);
            yield return (new Man("F8", Color.Black), Position.F8);
            yield return (new Man("F6", Color.Black), Position.F6);
            yield return (new Man("G7", Color.Black), Position.G7);
            yield return (new Man("H8", Color.Black), Position.H8);
            yield return (new Man("H6", Color.Black), Position.H6);
        }
    }

    public BoardSize BoardSize => new(8, 8);
    public IEnumerable<(Piece, Position)> PiecesPositions { get; }
    public PieceMoveFactory MoveFactory { get; }
    public PieceFactory PieceFactory { get; }
    public GameState GameState { get; }

    public static ClassicConfiguration NewBoard()
    {
        return new ClassicConfiguration(NewGamePieces, ClassicGameState.New);
    }

    public static ClassicConfiguration FromSnapshot(IEnumerable<(Piece, Position)> snapshot)
    {
        return new ClassicConfiguration(snapshot, ClassicGameState.New);
    }

    public static ClassicConfiguration FromSnapshot(IEnumerable<(Piece, Position)> snapshot, IEnumerable<Move> log)
    {
        return new ClassicConfiguration(snapshot, ClassicGameState.FromSnapshot(log));
    }
}