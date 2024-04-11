using Domain.Chessboard.GameStates;
using Domain.Chessboard.PieceMoves;
using Domain.Chessboard.Pieces;

namespace Domain.Chessboard.Configurations;

public interface Configuration
{
    public BoardSize BoardSize { get; }
    public IEnumerable<(Piece, Position)> PiecesPositions { get; }
    public PieceMoveFactory MoveFactory { get; }
    public PieceFactory PieceFactory { get; }
    public GameState GameState { get; }
}