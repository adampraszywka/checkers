using Domain;
using Domain.PieceMoves;

namespace DomainTests.PieceMoves.Classic.TestData;

public class PieceCaptureBlockTestCase
{
    public required Position SourcePiece { get; init; }
    public required IEnumerable<Position> CapturedPieces { get; init; }
    public required IEnumerable<Position> BlockingPieces { get; init; }
}