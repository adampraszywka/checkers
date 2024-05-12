using System.Collections;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class WhiteKingSimpleMoves : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = [], Blocking = [],
            Moves =
            [
                new(P.E5, [P.E5], 0), new(P.F6, [P.E5, P.F6], 0), new(P.G7, [P.E5, P.F6, P.G7], 0), new(P.H8, [P.E5, P.F6, P.G7, P.H8], 0),
                new(P.C5, [P.C5], 0), new(P.B6, [P.C5, P.B6], 0), new(P.A7, [P.C5, P.B6, P.A7], 0),
                new(P.C3, [P.C3], 0), new(P.B2, [P.C3, P.B2], 0), new(P.A1, [P.C3, P.B2, P.A1], 0),
                new(P.E3, [P.E3], 0), new(P.F2, [P.E3, P.F2], 0), new(P.G1, [P.E3, P.F2, P.G1], 0)
            ]
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.A1, Captured = [], Blocking = [],
            Moves =
            [
                new(P.B2, [P.B2], 0),
                new(P.C3, [P.B2, P.C3], 0),
                new(P.D4, [P.B2, P.C3, P.D4], 0),
                new(P.E5, [P.B2, P.C3, P.D4, P.E5], 0),
                new(P.F6, [P.B2, P.C3, P.D4, P.E5, P.F6], 0),
                new(P.G7, [P.B2, P.C3, P.D4, P.E5, P.F6, P.G7], 0),
                new(P.H8, [P.B2, P.C3, P.D4, P.E5, P.F6, P.G7, P.H8], 0),
            ]
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.A7, Captured = [], Blocking = [],
            Moves =
            [
                new (P.B8, [P.B8], 0), 
                new(P.B6, [P.B6], 0),
                new(P.C5, [P.B6, P.C5], 0),
                new(P.D4, [P.B6, P.C5, P.D4], 0),
                new(P.E3, [P.B6, P.C5, P.D4, P.E3], 0),
                new(P.F2, [P.B6, P.C5, P.D4, P.E3, P.F2], 0),
                new(P.G1, [P.B6, P.C5, P.D4, P.E3, P.F2, P.G1], 0)
            ]
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.H8, Blocking = [], Captured = [],
            Moves =
            [
                new(P.G7, [P.G7], 0),
                new(P.F6, [P.G7, P.F6], 0),
                new(P.E5, [P.G7, P.F6, P.E5], 0),
                new(P.D4, [P.G7, P.F6, P.E5, P.D4], 0),
                new(P.C3, [P.G7, P.F6, P.E5, P.D4, P.C3], 0),
                new(P.B2, [P.G7, P.F6, P.E5, P.D4, P.C3, P.B2], 0),
                new(P.A1, [P.G7, P.F6, P.E5, P.D4, P.C3, P.B2, P.A1], 0)
            ]
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.G1, Blocking = [], Captured = [],
            Moves =
            [
                new(P.H2, [P.H2], 0),
                new(P.F2, [P.F2], 0),
                new(P.E3, [P.F2, P.E3], 0),
                new(P.D4, [P.F2, P.E3, P.D4], 0),
                new(P.C5, [P.F2, P.E3, P.D4, P.C5], 0),
                new(P.B6, [P.F2, P.E3, P.D4, P.C5, P.B6], 0),
                new(P.A7, [P.F2, P.E3, P.D4, P.C5, P.B6, P.A7], 0)
            ]
        };
    }
}