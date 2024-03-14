using System.Text.Json;
using Domain;
using Domain.Configurations.Classic;
using Domain.PieceMoves.Classic;
using Domain.Pieces;
using DomainTests.PieceMoves.Classic.TestData;

namespace DomainTests.PieceMoves.Classic;

public class ClassicBlackManMovesTests
{
    [Test]
    [TestCaseSource(typeof(BlackManMovesForward))]
    public void PossibleMovesNoOtherPieceInteractions(MoveForwardTestCase testCase)
    {
        var piece = new Man("ID", Color.White);
        var configuration = ClassicConfiguration.FromSnapshot(new[] {((Piece) piece, SourceP: testCase.Source)});
        var board = new Board(configuration);
        var pieceMoves = new ClassicBlackManMoves();
        
        var moves = pieceMoves.PossibleMoves(testCase.Source, board.Snapshot);
        
        Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));
    }
    
    [Test]
    [TestCaseSource(typeof(BlackManMovesForwardBlockingMoves))]
    public void AnotherWhitePieceBlocks(BlockedMoveForwardTestCase testCase)
    {
        var piece1 = (Piece) new Man("ID", Color.Black);
        var pieces = new List<(Piece Piece, Position Position)> {(piece1, testCase.SourcePiece)};
        var blockingPieces = testCase.BlockingPieces
            .Select(x => ((Piece) new Man("ID", Color.Black), x));
        
        var configuration = ClassicConfiguration.FromSnapshot(pieces.Union(blockingPieces));
        var board = new Board(configuration);
        var pieceMoves = new ClassicBlackManMoves();
        
        var moves = pieceMoves.PossibleMoves(testCase.SourcePiece, board.Snapshot);
        
        Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));
    }
}