using System.Collections;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class BlackManMovesForward : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        // Row 8
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R8, P.B),
            Moves = new List<Move> { new(new P(P.R7, P.A), new[] {new P(P.R7, P.A)}, 0), new(new P(P.R7, P.C), new[] {new P(P.R7, P.C)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R8, P.D),
            Moves = new List<Move> { new(new P(P.R7, P.C), new[] {new P(P.R7, P.C)}, 0), new(new P(P.R7, P.E), new[] {new P(P.R7, P.E)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R8, P.F),
            Moves = new List<Move> { new(new P(P.R7, P.E), new[] {new P(P.R7, P.E)}, 0), new(new P(P.R7, P.G), new[] {new P(P.R7, P.G)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R8, P.H),
            Moves = new List<Move> { new(new P(P.R7, P.G), new[] {new P(P.R7, P.G)}, 0) }
        };

        // Row 7
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R7, P.A),
            Moves = new List<Move> { new(new P(P.R6, P.B), new[] {new P(P.R6, P.B)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R7, P.C),
            Moves = new List<Move> { new(new P(P.R6, P.B), new[] {new P(P.R6, P.B)}, 0), new(new P(P.R6, P.D), new[] {new P(P.R6, P.D)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R7, P.E),
            Moves = new List<Move> { new(new P(P.R6, P.D), new[] {new P(P.R6, P.D)}, 0), new(new P(P.R6, P.F), new[] {new P(P.R6, P.F)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R7, P.G),
            Moves = new List<Move> { new(new P(P.R6, P.F), new[] {new P(P.R6, P.F)}, 0), new(new P(P.R6, P.H), new[] {new P(P.R6, P.H)}, 0) }
        };

        // Row 6
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R6, P.B),
            Moves = new List<Move> { new(new P(P.R5, P.A), new[] {new P(P.R5, P.A)}, 0), new(new P(P.R5, P.C), new[] {new P(P.R5, P.C)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R6, P.D),
            Moves = new List<Move> { new(new P(P.R5, P.C), new[] {new P(P.R5, P.C)}, 0), new(new P(P.R5, P.E), new[] {new P(P.R5, P.E)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R6, P.F),
            Moves = new List<Move> { new(new P(P.R5, P.E), new[] {new P(P.R5, P.E)}, 0), new(new P(P.R5, P.G), new[] {new P(P.R5, P.G)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R6, P.H),
            Moves = new List<Move> { new(new P(P.R5, P.G), new[] {new P(P.R5, P.G)}, 0) }
        };

        // Row 5
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R5, P.A),
            Moves = new List<Move> { new(new P(P.R4, P.B), new[] {new P(P.R4, P.B)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R5, P.C),
            Moves = new List<Move> { new(new P(P.R4, P.B), new[] {new P(P.R4, P.B)}, 0), new(new P(P.R4, P.D), new[] {new P(P.R4, P.D)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R5, P.E),
            Moves = new List<Move> { new(new P(P.R4, P.D), new[] {new P(P.R4, P.D)}, 0), new(new P(P.R4, P.F), new[] {new P(P.R4, P.F)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R5, P.G),
            Moves = new List<Move> { new(new P(P.R4, P.F), new[] {new P(P.R4, P.F)}, 0), new(new P(P.R4, P.H), new[] {new P(P.R4, P.H)}, 0) }
        };

        // Row 4
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R4, P.B),
            Moves = new List<Move> { new(new P(P.R3, P.A), new[] {new P(P.R3, P.A)}, 0), new(new P(P.R3, P.C), new[] {new P(P.R3, P.C)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R4, P.D),
            Moves = new List<Move> { new(new P(P.R3, P.C), new[] {new P(P.R3, P.C)}, 0), new(new P(P.R3, P.E), new[] {new P(P.R3, P.E)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R4, P.F),
            Moves = new List<Move> { new(new P(P.R3, P.E), new[] {new P(P.R3, P.E)}, 0), new(new P(P.R3, P.G), new[] {new P(P.R3, P.G)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R4, P.H),
            Moves = new List<Move> { new(new P(P.R3, P.G), new[] {new P(P.R3, P.G)}, 0) }
        };

        // Row 3
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R3, P.A),
            Moves = new List<Move> { new(new P(P.R2, P.B), new[] {new P(P.R2, P.B)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R3, P.C),
            Moves = new List<Move> { new(new P(P.R2, P.B), new[] {new P(P.R2, P.B)}, 0), new(new P(P.R2, P.D), new[] {new P(P.R2, P.D)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R3, P.E),
            Moves = new List<Move> { new(new P(P.R2, P.D), new[] {new P(P.R2, P.D)}, 0), new(new P(P.R2, P.F), new[] {new P(P.R2, P.F)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R3, P.G),
            Moves = new List<Move> { new(new P(P.R2, P.F), new[] {new P(P.R2, P.F)}, 0), new(new P(P.R2, P.H), new[] {new P(P.R2, P.H)}, 0) }
        };
        
        // Row 2
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R2, P.B),
            Moves = new List<Move> { new(new P(P.R1, P.A), new[] {new P(P.R1, P.A)}, 0), new(new P(P.R1, P.C), new[] {new P(P.R1, P.C)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R2, P.D),
            Moves = new List<Move> { new(new P(P.R1, P.C), new[] {new P(P.R1, P.C)}, 0), new(new P(P.R1, P.E), new[] {new P(P.R1, P.E)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R2, P.F),
            Moves = new List<Move> { new(new P(P.R1, P.E), new[] {new P(P.R1, P.E)}, 0), new(new P(P.R1, P.G), new[] {new P(P.R1, P.G)}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = new P(P.R2, P.H),
            Moves = new List<Move> { new(new P(P.R1, P.G), new[] {new P(P.R1, P.G)}, 0) }
        };

        // Row 1
        yield return new MoveForwardTestCase { Source = new P(P.R1, P.A), Moves = new List<Move>() }; // No moves since it's at the edge
        yield return new MoveForwardTestCase { Source = new P(P.R1, P.C), Moves = new List<Move>() }; // No moves
        yield return new MoveForwardTestCase { Source = new P(P.R1, P.E), Moves = new List<Move>() }; // No moves
        yield return new MoveForwardTestCase { Source = new P(P.R1, P.G), Moves = new List<Move>() }; // No moves;
    }
}