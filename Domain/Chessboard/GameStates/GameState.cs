using Domain.Chessboard.Pieces;

namespace Domain.Chessboard.GameStates;

public interface GameState
{
    public GameStateSnapshot Snapshot { get; }
    public bool IsMoveAllowed(Piece piece);
    public void RegisterMove(Piece piece, Position source, Position target);
}