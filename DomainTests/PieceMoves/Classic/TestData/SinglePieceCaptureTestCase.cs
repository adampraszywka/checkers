using Domain;
using Domain.PieceMoves;

namespace DomainTests.PieceMoves.Classic.TestData;

public class SinglePieceCaptureTestCase
{
    public required Position SourcePiece { get; init; }
    public required Position CapturedPiece { get; init; }
    public required IEnumerable<Move> Moves { get; init; }
}
