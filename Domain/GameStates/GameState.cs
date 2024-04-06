using Domain.Pieces;

namespace Domain.GameStates;

public interface GameState
{
    public bool IsMoveAllowed(Piece piece);
    public void RegisterMove(Piece piece, Position source, Position target);
    public GameStateSnapshot Snapshot { get; }
}