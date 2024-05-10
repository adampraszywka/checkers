using Domain.Chessboard;
using Domain.Chessboard.PieceMoves.Classic;
using Domain.Shared;
using DomainTests.Chessboard.PieceMoves.Classic.TestData;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using DomainTests.Extensions;

namespace DomainTests.Chessboard.PieceMoves.Classic;

public class ClassicWhiteKingMovesTests
{
    [Test]
    [TestCaseSource(typeof(WhiteKingMoves))]
    public void KingMovesDiagonallyInEvertDirection(PieceCaptureTestCase testCase)
    {
        var board = testCase.BuildBoard(Color.White, Color.Black, Color.White);
        var pieceMoves = new ClassicWhiteKingMoves();

        var moves = pieceMoves.PossibleMoves(testCase.Source, board.Snapshot);

        MoveAssert.AreEqual(testCase.Moves, moves);
    }

    [Test]
    [TestCase(Position.R1, Position.B)]
    [TestCase(Position.R1, Position.D)]
    [TestCase(Position.R1, Position.F)]
    [TestCase(Position.R1, Position.H)]
    [TestCase(Position.R2, Position.B)]
    [TestCase(Position.R2, Position.D)]
    [TestCase(Position.R2, Position.F)]
    [TestCase(Position.R2, Position.H)]
    [TestCase(Position.R3, Position.B)]
    [TestCase(Position.R3, Position.D)]
    [TestCase(Position.R3, Position.F)]
    [TestCase(Position.R3, Position.H)]
    [TestCase(Position.R4, Position.B)]
    [TestCase(Position.R4, Position.D)]
    [TestCase(Position.R4, Position.F)]
    [TestCase(Position.R4, Position.H)]
    [TestCase(Position.R5, Position.B)]
    [TestCase(Position.R5, Position.D)]
    [TestCase(Position.R5, Position.F)]
    [TestCase(Position.R5, Position.H)]
    [TestCase(Position.R6, Position.B)]
    [TestCase(Position.R6, Position.D)]
    [TestCase(Position.R6, Position.F)]
    [TestCase(Position.R6, Position.H)]
    [TestCase(Position.R7, Position.B)]
    [TestCase(Position.R7, Position.D)]
    [TestCase(Position.R7, Position.F)]
    [TestCase(Position.R7, Position.H)]
    [TestCase(Position.R8, Position.B)]
    [TestCase(Position.R8, Position.D)]
    [TestCase(Position.R8, Position.F)]
    [TestCase(Position.R8, Position.H)]
    public void UpdateNotRequired(int row, int column)
    {
        var pieceMoves = new ClassicWhiteKingMoves();

        Assert.That(pieceMoves.UpgradeRequired(new Position(row, column)), Is.False);
    }
}