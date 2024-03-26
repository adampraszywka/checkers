using Domain;

namespace DomainTests.PieceMoves.Classic.TestData.Dto;

public class PieceForwardCaptureBlockTestCase
{
    public required Position SourcePiece { get; init; }
    public required IEnumerable<Position> CapturedPieces { get; init; }
    public required IEnumerable<Position> BlockingPieces { get; init; }
}