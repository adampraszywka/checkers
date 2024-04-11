using Domain.Chessboard;
using Domain.Chessboard.Configurations;
using Domain.Chessboard.GameStates;
using Domain.Chessboard.PieceMoves;
using Domain.Chessboard.Pieces;

namespace DomainTests.Extensions;

public class TestConfiguration(
    PieceMoveFactory moveFactory,
    PieceFactory pieceFactory,
    IEnumerable<(Piece, Position)> piecesPositions,
    GameState gameState)
    : Configuration
{
    public BoardSize BoardSize { get; } = new(8, 8);
    public IEnumerable<(Piece, Position)> PiecesPositions { get; } = piecesPositions;
    public PieceMoveFactory MoveFactory { get; } = moveFactory;
    public PieceFactory PieceFactory { get; } = pieceFactory;
    public GameState GameState { get; } = gameState;
}