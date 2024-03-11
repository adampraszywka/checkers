using System.Collections;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhiteManMovesForward : IEnumerable<TestCase>
{
    public IEnumerator<TestCase> GetEnumerator()
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
        
        //Row3
        yield return new TestCase
        {
            Source = new P(P.R3, P.A),
            Moves = new List<Move> {new(new P(P.R4, P.B), new[] {new P(P.R4, P.B)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R3, P.C),
            Moves = new List<Move> {new(new P(P.R4, P.B), new[] {new P(P.R4, P.B)}, 0), new(new P(P.R4, P.D), new[] {new P(P.R4, P.D)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R3, P.E),
            Moves = new List<Move> {new(new P(P.R4, P.D), new[] {new P(P.R4, P.D)}, 0), new(new P(P.R4, P.F), new[] {new P(P.R4, P.F)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R3, P.G),
            Moves = new List<Move> {new(new P(P.R4, P.F), new[] {new P(P.R4, P.F)}, 0), new(new P(P.R4, P.H), new[] {new P(P.R4, P.H)}, 0)}
        };

        //Row4
        yield return new TestCase
        {
            Source = new P(P.R4, P.B),
            Moves = new List<Move> {new(new P(P.R5, P.A), new[] {new P(P.R5, P.A)}, 0), new(new P(P.R5, P.C), new[] {new P(P.R5, P.C)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R4, P.D),
            Moves = new List<Move> {new(new P(P.R5, P.C), new[] {new P(P.R5, P.C)}, 0), new(new P(P.R5, P.E), new[] {new P(P.R5, P.E)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R4, P.F),
            Moves = new List<Move> {new(new P(P.R5, P.E), new[] {new P(P.R5, P.E)}, 0), new(new P(P.R5, P.G), new[] {new P(P.R5, P.G)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R4, P.H),
            Moves = new List<Move> {new(new P(P.R5, P.G), new[] {new P(P.R5, P.G)}, 0)}
        };
        
        // Row5
        yield return new TestCase
        {
            Source = new P(P.R5, P.A),
            Moves = new List<Move> {new(new P(P.R6, P.B), new[] {new P(P.R6, P.B)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R5, P.C),
            Moves = new List<Move> {new(new P(P.R6, P.B), new[] {new P(P.R6, P.B)}, 0), new(new P(P.R6, P.D), new[] {new P(P.R6, P.D)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R5, P.E),
            Moves = new List<Move> {new(new P(P.R6, P.D), new[] {new P(P.R6, P.D)}, 0), new(new P(P.R6, P.F), new[] {new P(P.R6, P.F)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R5, P.G),
            Moves = new List<Move> {new(new P(P.R6, P.F), new[] {new P(P.R6, P.F)}, 0), new(new P(P.R6, P.H), new[] {new P(P.R6, P.H)}, 0)}
        };

        //Row6
        yield return new TestCase
        {
            Source = new P(P.R6, P.B),
            Moves = new List<Move> {new(new P(P.R7, P.A), new[] {new P(P.R7, P.A)}, 0), new(new P(P.R7, P.C), new[] {new P(P.R7, P.C)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R6, P.D),
            Moves = new List<Move> {new(new P(P.R7, P.C), new[] {new P(P.R7, P.C)}, 0), new(new P(P.R7, P.E), new[] {new P(P.R7, P.E)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R6, P.F),
            Moves = new List<Move> {new(new P(P.R7, P.E), new[] {new P(P.R7, P.E)}, 0), new(new P(P.R7, P.G), new[] {new P(P.R7, P.G)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R6, P.H),
            Moves = new List<Move> {new(new P(P.R7, P.G), new[] {new P(P.R7, P.G)}, 0)}
        };

        //Row7
        yield return new TestCase
        {
            Source = new P(P.R7, P.A),
            Moves = new List<Move> {new(new P(P.R8, P.B), new[] {new P(P.R8, P.B)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R7, P.C),
            Moves = new List<Move> {new(new P(P.R8, P.B), new[] {new P(P.R8, P.B)}, 0), new(new P(P.R8, P.D), new[] {new P(P.R8, P.D)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R7, P.E),
            Moves = new List<Move> {new(new P(P.R8, P.D), new[] {new P(P.R8, P.D)}, 0), new(new P(P.R8, P.F), new[] {new P(P.R8, P.F)}, 0)}
        };
        yield return new TestCase
        {
            Source = new P(P.R7, P.G),
            Moves = new List<Move> {new(new P(P.R8, P.F), new[] {new P(P.R8, P.F)}, 0), new(new P(P.R8, P.H), new[] {new P(P.R8, P.H)}, 0)}
        };
        
        //Row8
        yield return new TestCase { Source = new P(P.R8, P.B), Moves = new List<Move>() };
        yield return new TestCase { Source = new P(P.R8, P.D), Moves = new List<Move>() };
        yield return new TestCase { Source = new P(P.R8, P.F), Moves = new List<Move>() };
        yield return new TestCase { Source = new P(P.R8, P.H), Moves = new List<Move>() };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}