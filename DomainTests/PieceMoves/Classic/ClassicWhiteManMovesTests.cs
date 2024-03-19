using System.Collections;
using System.Text.Json;
using Domain;
using Domain.Configurations.Classic;
using Domain.PieceMoves;
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

    public class SinglePieceCaptureTestCase
    {
        public required Position SourcePiece { get; init; }
        public required Position CapturedPiece { get; init; }
        public required IEnumerable<Move> Moves { get; init; }
    }


    public class WhitePieceCapturesSingleBlackPieceTestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new SinglePieceCaptureTestCase
            {
                SourcePiece = new Position(Position.R1, Position.A), CapturedPiece = new Position(Position.R2, Position.B),
                Moves = new[]
                {
                    new Move(new Position(Position.R3, Position.C), new[] {new Position(Position.R2, Position.B)}, 1)
                }
            };
            
            yield return new SinglePieceCaptureTestCase
            {
                SourcePiece = new Position(Position.R1, Position.C), CapturedPiece = new Position(Position.R2, Position.B),
                Moves = new[]
                {
                    new Move(new Position(Position.R3, Position.A), new[] {new Position(Position.R2, Position.B)}, 1),
                }
            };
            
            yield return new SinglePieceCaptureTestCase
            {
                SourcePiece = new Position(Position.R1, Position.C), CapturedPiece = new Position(Position.R2, Position.D),
                Moves = new[]
                {
                    new Move(new Position(Position.R3, Position.E), new[] {new Position(Position.R2, Position.D)}, 1),
                }
            };
        }
    }
    
    [Ignore("Work in progress!")]
    [TestCaseSource(typeof(WhitePieceCapturesSingleBlackPieceTestCases))]
    public void WhitePieceCapturesSingleBlackPiece(SinglePieceCaptureTestCase testCase)
    {
        var white = (Piece) new Man("W", Color.White);
        var black = (Piece) new Man("B", Color.White);
        var piece = new List<(Piece Piece, Position Position)> {(white, testCase.SourcePiece)};
        var capturedPieces = new List<(Piece Piece, Position Position)> {(black, testCase.CapturedPiece)};
        
        var configuration = ClassicConfiguration.FromSnapshot(piece.Union(capturedPieces));
        var board = new Board(configuration);
        var pieceMoves = new ClassicWhiteManMoves();
        
        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);
        
        Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));

    }
    
    // [Test]
    // public void SingleBlackPieceCapture()
    // {
    //     var whiteMan = (Piece) new Man("W", Color.White);
    //     var blackMan = (Piece) new Man("B", Color.Black);
    //     var source = new Position(Position.R1, Position.A);
    //     
    //     var configuration = ClassicConfiguration.FromSnapshot(new[]
    //     {
    //         (whiteMan, source),
    //         (blackMan, new Position(Position.R2, Position.B)),
    //     });
    //     var board = new Board(configuration);
    //     var pieceMoves = new ClassicWhiteManMoves();
    //     
    //     var moves = pieceMoves.PossibleMoves(source, board.Snapshot);
    //     
    //     
    //     
    //     Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));
    // }
}