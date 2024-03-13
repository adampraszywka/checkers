using Domain;
using Domain.PieceMoves;

namespace DomainTests.PieceMoves.Classic.TestData;

public class BlockedMoveForwardTestCase
{
    public required Position SourcePiece { get; init; }
    public required IEnumerable<Position> BlockingPieces { get; init; }
    public required IEnumerable<Move> Moves { get; init; }
}