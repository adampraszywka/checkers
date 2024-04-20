using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;

public class PieceCaptureTestCase
{
    public required Position Source { get; init; }
    public IEnumerable<Position> Captured { get; init; } = Enumerable.Empty<Position>();
    public IEnumerable<PossibleMove> Moves { get; init; } = Enumerable.Empty<PossibleMove>();
    public IEnumerable<Position> Blocking { get; init; } = Enumerable.Empty<Position>();
}