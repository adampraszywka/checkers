using Domain.Chessboard.GameStates;
using Domain.Chessboard.PieceMoves;
using Domain.Shared;
using FluentResults;

namespace Domain.Chessboard;

public interface Board
{
    public string Id { get; }
    public Participants Participants { get; }
    public BoardSnapshot Snapshot { get; }
    public GameStateSnapshot GameState { get; }
    public Result<IEnumerable<PossibleMove>> PossibleMoves(Player player, Position source);
    public Result Move(Player player, Position source, Position target);
}