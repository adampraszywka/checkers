using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;

public class PieceCaptureTestCase
{
    public required Position SourcePiece { get; init; }
    public required IEnumerable<Position> CapturedPieces { get; init; }
    public required IEnumerable<PossibleMove> Moves { get; init; }
}