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
            Source = P.B8,
            Moves = new List<Move> { new(P.A7, new[] {P.A7}, 0), new(P.C7, new[] {P.C7}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.D8,
            Moves = new List<Move> { new(P.C7, new[] {P.C7}, 0), new(P.E7, new[] {P.E7}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.F8,
            Moves = new List<Move> { new(P.E7, new[] {P.E7}, 0), new(P.G7, new[] {P.G7}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.H8,
            Moves = new List<Move> { new(P.G7, new[] {P.G7}, 0) }
        };

        // Row 7
        yield return new MoveForwardTestCase
        {
            Source = P.A7,
            Moves = new List<Move> { new(P.B6, new[] {P.B6}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.C7,
            Moves = new List<Move> { new(P.B6, new[] {P.B6}, 0), new(P.D6, new[] {P.D6}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.E7,
            Moves = new List<Move> { new(P.D6, new[] {P.D6}, 0), new(P.F6, new[] {P.F6}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.G7,
            Moves = new List<Move> { new(P.F6, new[] {P.F6}, 0), new(P.H6, new[] {P.H6}, 0) }
        };

        // Row 6
        yield return new MoveForwardTestCase
        {
            Source = P.B6,
            Moves = new List<Move> { new(P.A5, new[] {P.A5}, 0), new(P.C5, new[] {P.C5}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.D6,
            Moves = new List<Move> { new(P.C5, new[] {P.C5}, 0), new(P.E5, new[] {P.E5}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.F6,
            Moves = new List<Move> { new(P.E5, new[] {P.E5}, 0), new(P.G5, new[] {P.G5}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.H6,
            Moves = new List<Move> { new(P.G5, new[] {P.G5}, 0) }
        };

        // Row 5
        yield return new MoveForwardTestCase
        {
            Source = P.A5,
            Moves = new List<Move> { new(P.B4, new[] {P.B4}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.C5,
            Moves = new List<Move> { new(P.B4, new[] {P.B4}, 0), new(P.D4, new[] {P.D4}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.E5,
            Moves = new List<Move> { new(P.D4, new[] {P.D4}, 0), new(P.F4, new[] {P.F4}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.G5,
            Moves = new List<Move> { new(P.F4, new[] {P.F4}, 0), new(P.H4, new[] {P.H4}, 0) }
        };

        // Row 4
        yield return new MoveForwardTestCase
        {
            Source = P.B4,
            Moves = new List<Move> { new(P.A3, new[] {P.A3}, 0), new(P.C3, new[] {P.C3}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.D4,
            Moves = new List<Move> { new(P.C3, new[] {P.C3}, 0), new(P.E3, new[] {P.E3}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.F4,
            Moves = new List<Move> { new(P.E3, new[] {P.E3}, 0), new(P.G3, new[] {P.G3}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.H4,
            Moves = new List<Move> { new(P.G3, new[] {P.G3}, 0) }
        };

        // Row 3
        yield return new MoveForwardTestCase
        {
            Source = P.A3,
            Moves = new List<Move> { new(P.B2, new[] {P.B2}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.C3,
            Moves = new List<Move> { new(P.B2, new[] {P.B2}, 0), new(P.D2, new[] {P.D2}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.E3,
            Moves = new List<Move> { new(P.D2, new[] {P.D2}, 0), new(P.F2, new[] {P.F2}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.G3,
            Moves = new List<Move> { new(P.F2, new[] {P.F2}, 0), new(P.H2, new[] {P.H2}, 0) }
        };
        
        // Row 2
        yield return new MoveForwardTestCase
        {
            Source = P.B2,
            Moves = new List<Move> { new(P.A1, new[] {P.A1}, 0), new(P.C1, new[] {P.C1}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.D2,
            Moves = new List<Move> { new(P.C1, new[] {P.C1}, 0), new(P.E1, new[] {P.E1}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.F2,
            Moves = new List<Move> { new(P.E1, new[] {P.E1}, 0), new(P.G1, new[] {P.G1}, 0) }
        };
        yield return new MoveForwardTestCase
        {
            Source = P.H2,
            Moves = new List<Move> { new(P.G1, new[] {P.G1}, 0) }
        };

        // Row 1
        yield return new MoveForwardTestCase { Source = P.A1, Moves = new List<Move>() }; // No moves since it's at the edge
        yield return new MoveForwardTestCase { Source = P.C1, Moves = new List<Move>() }; // No moves
        yield return new MoveForwardTestCase { Source = P.E1, Moves = new List<Move>() }; // No moves
        yield return new MoveForwardTestCase { Source = P.G1, Moves = new List<Move>() }; // No moves;
    }
}