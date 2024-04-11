using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Chessboard.PieceMoves.Classic;
using Domain.Chessboard.Pieces;
using Domain.Chessboard.Pieces.Classic;
using DomainTests.Chessboard.PieceMoves.Classic.TestData;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using DomainTests.Extensions;

namespace DomainTests.Chessboard.PieceMoves.Classic;

public class ClassicBlackManMovesTests
{
    [Test]
    [TestCaseSource(typeof(BlackManMovesForward))]
    public void PossibleMovesNoOtherPieceInteractions(MoveForwardTestCase testCase)
    {
        var piece = new Man("ID", Color.White);
        var configuration = ClassicConfiguration.FromSnapshot(new[] {((Piece) piece, SourceP: testCase.Source)});
        var board = new Board("ID", configuration);
        var pieceMoves = new ClassicBlackManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.Source, board.Snapshot);

        MoveAssert.AreEqual(testCase.Moves, moves);
    }

    [Test]
    [TestCaseSource(typeof(BlackManMovesForwardBlockingMoves))]
    public void AnotherBlackPieceBlocks(BlockedMoveForwardTestCase testCase)
    {
        var piece1 = (Piece) new Man("ID", Color.Black);
        var pieces = new List<(Piece Piece, Position Position)> {(piece1, testCase.SourcePiece)};
        var blockingPieces = testCase.BlockingPieces
            .Select(x => ((Piece) new Man("ID", Color.Black), x));

        var configuration = ClassicConfiguration.FromSnapshot(pieces.Union(blockingPieces));
        var board = new Board("ID", configuration);
        var pieceMoves = new ClassicBlackManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);

        MoveAssert.AreEqual(testCase.Moves, moves);
    }

    [TestCaseSource(typeof(BlackPieceCapturesForwardWhitePieceTestCases))]
    [TestCaseSource(typeof(BlackPieceCapturesBackwardWhitePieceTestCases))]
    public void BlackPieceCapturesBlackPieces(PieceCaptureTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.Black);
        var piece = new List<(Piece Piece, Position Position)> {(black, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (white, x));

        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces));
        var board = new Board("ID", configuration);
        var pieceMoves = new ClassicBlackManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);

        MoveAssert.AreEqual(testCase.Moves, moves);
    }

    [Test]
    [TestCaseSource(typeof(BlackPieceForwardCaptureBlockedByAnotherPiece))]
    public void BlackPieceCaptureForwardBlockedByDifferentPiece(PieceForwardCaptureBlockTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.Black);
        var blockingPiece = (Piece) new Man("B", Color.White);
        var piece = new List<(Piece Piece, Position Position)> {(black, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (white, x));
        var blockingPieces = testCase.BlockingPieces.Select(x => (blockingPiece, x));

        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces).Union(blockingPieces));
        var board = new Board("ID", configuration);
        var pieceMoves = new ClassicBlackManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);

        Assert.That(moves, Is.Empty);
    }

    [Test]
    [TestCaseSource(typeof(BlackPieceBackwardCaptureBlockedByAnotherPiece))]
    public void BlackPieceCaptureBackwardBlockedByDifferentPiece(PieceBackwardCaptureBlockTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.Black);
        var blockingPiece = (Piece) new Man("B", Color.Black);
        var piece = new List<(Piece Piece, Position Position)> {(black, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (white, x));
        var blockingPieces = testCase.BlockingPieces.Select(x => (blockingPiece, x));

        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces).Union(blockingPieces));
        var board = new Board("ID", configuration);
        var pieceMoves = new ClassicBlackManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);

        MoveAssert.AreEqual(testCase.Moves, moves);
    }


    [Test]
    [TestCase(Position.R1, Position.B)]
    [TestCase(Position.R1, Position.D)]
    [TestCase(Position.R1, Position.F)]
    [TestCase(Position.R1, Position.H)]
    public void UpgradeRequired(int row, int column)
    {
        var pieceMoves = new ClassicBlackManMoves();

        Assert.True(pieceMoves.UpgradeRequired(new Position(row, column)));
    }

    [Test]
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
    public void UpgradeNotRequired(int row, int column)
    {
        var pieceMoves = new ClassicBlackManMoves();

        Assert.False(pieceMoves.UpgradeRequired(new Position(row, column)));
    }
}