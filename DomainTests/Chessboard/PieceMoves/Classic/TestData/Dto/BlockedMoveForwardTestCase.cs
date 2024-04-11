using Domain.Chessboard;
using Domain.Chessboard.PieceMoves;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;

public class BlockedMoveForwardTestCase
{
    public required Position SourcePiece { get; init; }
    public required IEnumerable<Position> BlockingPieces { get; init; }
    public required IEnumerable<PossibleMove> Moves { get; init; }
}