using Domain.Chessboard.Pieces;

namespace Domain.Chessboard.GameStates;

public class ClassicGameState : GameState
{
    private readonly List<Move> _log;


    private ClassicGameState(IEnumerable<Move> log)
    {
        _log = log.ToList();
    }

    public static ClassicGameState New => new(Enumerable.Empty<Move>());

    public GameStateSnapshot Snapshot => CreateSnapshot();

    public bool IsMoveAllowed(Piece piece)
    {
        return piece.Color == GetCurrentPlayerColor();
    }

    public void RegisterMove(Piece piece, Position source, Position target)
    {
        _log.Add(new Move(piece, source, target));
    }

    public static ClassicGameState FromSnapshot(IEnumerable<Move> log)
    {
        return new ClassicGameState(log);
    }

    private Color GetCurrentPlayerColor()
    {
        if (_log.Count == 0) return Color.White;

        if (_log.Last().Piece.Color == Color.White) return Color.Black;

        return Color.White;
    }

    private GameStateSnapshot CreateSnapshot()
    {
        return new GameStateSnapshot(_log, GetCurrentPlayerColor());
    }
}