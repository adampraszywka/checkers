using System.Text.Json;
using Domain;
using Domain.Configurations.Classic;
using Domain.Pieces;
using P = Domain.Position;
namespace DomainTests.Pieces;


public class WhiteManTests
{
    public class TestCase
    {
        public required P Source { get; init; }
        public required IEnumerable<Move> Moves { get; init; }
    }
    
    public static IEnumerable<TestCase> PossibleMoves()
    {
        // Row1
        yield return new TestCase
        {
            Source = new P(P.R1, P.A),
            Moves = new List<Move> {new(new P(P.R2, P.B), new[] {new P(P.R2, P.B)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R1, P.C),
            Moves = new List<Move> {new(new P(P.R2, P.B), new[] {new P(P.R2, P.B)}, 0), new(new P(P.R2, P.D), new[] {new P(P.R2, P.D)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R1, P.E),
            Moves = new List<Move> {new(new P(P.R2, P.D), new[] {new P(P.R2, P.D)}, 0), new(new P(P.R2, P.F), new[] {new P(P.R2, P.F)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R1, P.G),
            Moves = new List<Move> {new(new P(P.R2, P.F), new[] {new P(P.R2, P.F)}, 0), new(new P(P.R2, P.H), new[] {new P(P.R2, P.H)}, 0)}
        };
        
        //Row2
        yield return new TestCase
        {
            Source = new P(P.R2, P.B),
            Moves = new List<Move> {new(new P(P.R3, P.A), new[] {new P(P.R3, P.A)}, 0), new(new P(P.R3, P.C), new[] {new P(P.R3, P.C)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R2, P.D),
            Moves = new List<Move> {new(new P(P.R3, P.C), new[] {new P(P.R3, P.C)}, 0), new(new P(P.R3, P.E), new[] {new P(P.R3, P.E)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R2, P.F),
            Moves = new List<Move> {new(new P(P.R3, P.E), new[] {new P(P.R3, P.E)}, 0), new(new P(P.R3, P.G), new[] {new P(P.R3, P.G)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R2, P.H),
            Moves = new List<Move> {new(new P(P.R3, P.G), new[] {new P(P.R3, P.G)}, 0)}
        };
        
        //Row7
        yield return new TestCase { Source = new P(P.R8, P.B), Moves = new List<Move>() };
        yield return new TestCase { Source = new P(P.R8, P.D), Moves = new List<Move>() };
        yield return new TestCase { Source = new P(P.R8, P.F), Moves = new List<Move>() };
        yield return new TestCase { Source = new P(P.R8, P.H), Moves = new List<Move>() };

    }
    
    [Test]
    [TestCaseSource(nameof(PossibleMoves))]
    public void PossibleMovesNoOtherPieceInteractions(TestCase testCase)
    {
        var piece = new Man("ID", Color.White);
        var configuration = ClassicConfiguration.FromSnapshot(new[] {((Piece) piece, SourceP: testCase.Source)});
        var board = new Board(configuration);

        var moves = piece.PossibleMoves(board.Snapshot);
        
        Assert.That(JsonSerializer.Serialize(moves), Is.EqualTo(JsonSerializer.Serialize(testCase.Moves)));
    }
}