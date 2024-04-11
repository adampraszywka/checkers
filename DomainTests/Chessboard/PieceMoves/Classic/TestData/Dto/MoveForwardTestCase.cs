using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;

public class MoveForwardTestCase
{
    public required Position Source { get; init; }
    public required IEnumerable<PossibleMove> Moves { get; init; }
}