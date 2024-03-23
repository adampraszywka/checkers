using System.Text.Json;
using Domain;
using Domain.Configurations.Classic;
using Domain.PieceMoves.Classic;
using Domain.Pieces;
using DomainTests.PieceMoves.Classic.TestData;

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

        Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));
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

        Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));
    }
    
    [TestCaseSource(typeof(WhitePieceCapturesForwardBlackPiecesTestCases))]
    public void WhitePieceCapturesBlackPieces(SinglePieceCaptureTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.Black);
        var piece = new List<(Piece Piece, Position Position)> {(white, testCase.SourcePiece)};
        var capturedPieces = testCase.CapturedPieces.Select(x => (black, x));

        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces));
        var board = new Board(configuration);
        var pieceMoves = new ClassicWhiteManMoves();

        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);

        Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));
    }
}