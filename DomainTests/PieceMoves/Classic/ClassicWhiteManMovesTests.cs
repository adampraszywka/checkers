using Domain;
using Domain.Configurations.Classic;
using Domain.PieceMoves.Classic;
using Domain.Pieces;
using Domain.Pieces.Classic;
using DomainTests.Extensions;
using DomainTests.PieceMoves.Classic.TestData;
using DomainTests.PieceMoves.Classic.TestData.Dto;

namespace DomainTests.PieceMoves.Classic;

public class ClassicWhiteManMovesTests
{
    [Test]
    [TestCaseSource(typeof(WhiteManMovesForward))]
    public void PossibleMovesNoOtherPieceInteractions(MoveForwardTestCase testCase)
    {
        var piece = new Man("ID", Color.White);
        var configuration = ClassicConfiguration.FromSnapshot(new[] {((Piece) piece, testCase.Source)});
        var board = new Board(configuration);
        var pieceMoves = new ClassicWhiteManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.Source, board.Snapshot);

        MoveAssert.AreEqual(testCase.Moves, moves);
    }

    [Test]
    [TestCaseSource(typeof(WhiteManMovesForwardBlockingMoves))]
    public void AnotherWhitePieceBlocks(BlockedMoveForwardTestCase testCase)
    {
        var piece1 = (Piece) new Man("ID", Color.White);
        var pieces = new List<(Piece Piece, Position Position)> {(piece1, testCase.SourcePiece)};
        var blockingPieces = testCase.BlockingPieces
            .Select(x => ((Piece) new Man("ID", Color.White), x));

        var configuration = ClassicConfiguration.FromSnapshot(pieces.Union(blockingPieces));
        var board = new Board(configuration);
        var pieceMoves = new ClassicWhiteManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);

        MoveAssert.AreEqual(testCase.Moves, moves);
    }
    
    [Test]
    [TestCaseSource(typeof(WhitePieceCapturesForwardBlackPiecesTestCases))]
    [TestCaseSource(typeof(WhitePieceCapturesBackwardBlackPiecesTestCases))]
    public void WhitePieceCapturesBlackPieces(PieceCaptureTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.Black);
        var piece = new List<(Piece Piece, Position Position)> {(white, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (black, x));

        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces));
        var board = new Board(configuration);
        var pieceMoves = new ClassicWhiteManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);
     
        MoveAssert.AreEqual(testCase.Moves, moves);
    }

    [Test]
    [TestCaseSource(typeof(WhitePieceForwardCaptureBlockedByAnotherPiece))]
    public void WhitePieceCaptureForwardBlockedByDifferentPiece(PieceForwardCaptureBlockTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.Black);
        var blockingPiece = (Piece) new Man("B", Color.Black);
        var piece = new List<(Piece Piece, Position Position)> {(white, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (black, x));
        var blockingPieces = testCase.BlockingPieces.Select(x => (blockingPiece, x));

        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces).Union(blockingPieces));
        var board = new Board(configuration);
        var pieceMoves = new ClassicWhiteManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);
     
        Assert.That(moves, Is.Empty);
    }
    
    [Test]
    [TestCaseSource(typeof(WhitePieceBackwardCaptureBlockedByAnotherPiece))]
    public void WhitePieceCaptureBackwardBlockedByDifferentPiece(PieceBackwardCaptureBlockTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.Black);
        var blockingPiece = (Piece) new Man("B", Color.Black);
        var piece = new List<(Piece Piece, Position Position)> {(white, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (black, x));
        var blockingPieces = testCase.BlockingPieces.Select(x => (blockingPiece, x));

        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces).Union(blockingPieces));
        var board = new Board(configuration);
        var pieceMoves = new ClassicWhiteManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);
     
        MoveAssert.AreEqual(testCase.Moves, moves);
    }
    
    [Test]
    [TestCase(Position.R8, Position.B)]
    [TestCase(Position.R8, Position.D)]
    [TestCase(Position.R8, Position.F)]
    [TestCase(Position.R8, Position.H)]
    public void UpgradeRequired(int row, int column)
    {
        var pieceMoves = new ClassicWhiteManMoves();
        
        Assert.True(pieceMoves.UpdateRequired(new Position(row, column)));
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
    public void UpgradeNotRequired(int row, int column)
    {
        var pieceMoves = new ClassicWhiteManMoves();
        
        Assert.False(pieceMoves.UpdateRequired(new Position(row, column)));
    }
}