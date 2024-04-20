using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;

public class PieceCaptureTestCase
{
    public required Position SourcePiece { get; init; }
    public IEnumerable<Position> CapturedPieces { get; init; } = Enumerable.Empty<Position>();
    public IEnumerable<PossibleMove> Moves { get; init; } = Enumerable.Empty<PossibleMove>();
    public IEnumerable<Position> BlockingPieces { get; init; } = Enumerable.Empty<Position>();
}