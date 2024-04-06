using Domain.Pieces;

namespace Domain.GameStates;

public class ClassicGameState : GameState
{
    private readonly List<Move> _log;
    
    public GameStateSnapshot Snapshot => CreateSnapshot();
    
    public static ClassicGameState New => new(Enumerable.Empty<Move>());
    public static ClassicGameState FromSnapshot(IEnumerable<Move> log) => new(log);


    private ClassicGameState(IEnumerable<Move> log)
    {
        _log = log.ToList();
    }

    public bool IsMoveAllowed(Piece piece) => piece.Color == GetCurrentPlayerColor();

    public void RegisterMove(Piece piece, Position source, Position target)
    {
        _log.Add(new Move(piece, source, target));
    }
    
    private Color GetCurrentPlayerColor()
    {
        if (_log.Count == 0)
        {
            return Color.White;
        }

        if (_log.Last().Piece.Color == Color.White)
        {
            return Color.Black;
        }

        return Color.White;
    }

    private GameStateSnapshot CreateSnapshot() => new(_log, GetCurrentPlayerColor());
}