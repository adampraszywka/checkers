using Domain;
using Domain.Configurations;
using Domain.Log;
using Domain.PieceMoves;
using Domain.Pieces;

namespace DomainTests.Extensions;

public class TestConfiguration(
    PieceMoveFactory moveFactory,
    PieceFactory pieceFactory,
    IEnumerable<(Piece, Position)> piecesPositions)
    : Configuration
{
    public BoardSize BoardSize { get; } = new(8, 8);
    public IEnumerable<(Piece, Position)> PiecesPositions { get; } = piecesPositions;
    public PieceMoveFactory MoveFactory { get; } = moveFactory;
    public PieceFactory PieceFactory { get; } = pieceFactory;
    public IEnumerable<Move> Log { get; } = Enumerable.Empty<Move>();
}