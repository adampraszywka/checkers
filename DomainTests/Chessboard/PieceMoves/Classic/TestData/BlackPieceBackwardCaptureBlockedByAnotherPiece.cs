using System.Collections;
using Domain.Chessboard.PieceMoves;
using P = Domain.Chessboard.Position;
using TestCase = DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto.PieceCaptureTestCase;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class BlackPieceBackwardCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCase
        {
            Source = P.B2, Captured = [P.A3, P.C3], Blocking = [P.D4],
            Moves = [new PossibleMove(P.A1, [P.A1], 0), new PossibleMove(P.C1, [P.C1], 0)]
        };
        yield return new TestCase
        {
            Source = P.D2, Captured = [P.C3, P.E3], Blocking = [P.B4, P.F4],
            Moves = [new PossibleMove(P.C1, [P.C1], 0), new PossibleMove(P.E1, [P.E1], 0)]
        };
        yield return new TestCase
        {
            Source = P.F2, Captured = [P.E3, P.G3], Blocking = [P.D4, P.H4],
            Moves = [new PossibleMove(P.E1, [P.E1], 0), new PossibleMove(P.G1, [P.G1], 0)]
        };
        yield return new TestCase
        {
            Source = P.H2, Captured = [P.G3], Blocking = [P.F4],
            Moves = [new PossibleMove(P.G1, [P.G1], 0)]
        };

        yield return new TestCase
        {
            Source = P.A3, Captured = [P.B4], Blocking = [P.C5],
            Moves = [new PossibleMove(P.B2, [P.B2], 0)]
        };
        yield return new TestCase
        {
            Source = P.C3, Captured = [P.B4, P.D4], Blocking = [P.A5, P.E5],
            Moves = [new PossibleMove(P.B2, [P.B2], 0), new PossibleMove(P.D2, [P.D2], 0)]
        };
        yield return new TestCase
        {
            Source = P.E3, Captured = [P.D4, P.F4], Blocking = [P.C5, P.G5],
            Moves = [new PossibleMove(P.D2, [P.D2], 0), new PossibleMove(P.F2, [P.F2], 0)]
        };
        yield return new TestCase
        {
            Source = P.G3, Captured = [P.F4, P.H4], Blocking = [P.E5],
            Moves = [new PossibleMove(P.F2, [P.F2], 0), new PossibleMove(P.H2, [P.H2], 0)]
        };

        yield return new TestCase
        {
            Source = P.B4, Captured = [P.A5, P.C5], Blocking = [P.D6],
            Moves = [new PossibleMove(P.A3, [P.A3], 0), new PossibleMove(P.C3, [P.C3], 0)]
        };
        yield return new TestCase
        {
            Source = P.D4, Captured = [P.C5, P.E5], Blocking = [P.B6, P.F6],
            Moves = [new PossibleMove(P.C3, [P.C3], 0), new PossibleMove(P.E3, [P.E3], 0)]
        };
        yield return new TestCase
        {
            Source = P.F4, Captured = [P.E5, P.G5], Blocking = [P.D6, P.H6],
            Moves = [new PossibleMove(P.E3, [P.E3], 0), new PossibleMove(P.G3, [P.G3], 0)]
        };
        yield return new TestCase
        {
            Source = P.H4, Captured = [P.G5], Blocking = [P.F6],
            Moves = [new PossibleMove(P.G3, [P.G3], 0)]
        };

        yield return new TestCase
        {
            Source = P.A5, Captured = [P.B6], Blocking = [P.C7],
            Moves = [new PossibleMove(P.B4, [P.B4], 0)]
        };
        yield return new TestCase
        {
            Source = P.C5, Captured = [P.B6, P.D6], Blocking = [P.A7, P.E7],
            Moves = [new PossibleMove(P.B4, [P.B4], 0), new PossibleMove(P.D4, [P.D4], 0)]
        };
        yield return new TestCase
        {
            Source = P.E5, Captured = [P.D6, P.F6], Blocking = [P.C7, P.G7],
            Moves = [new PossibleMove(P.D4, [P.D4], 0), new PossibleMove(P.F4, [P.F4], 0)]
        };
        yield return new TestCase
        {
            Source = P.G5, Captured = [P.F6, P.H6], Blocking = [P.E7],
            Moves = [new PossibleMove(P.F4, [P.F4], 0), new PossibleMove(P.H4, [P.H4], 0)]
        };

        yield return new TestCase
        {
            Source = P.B6, Captured = [P.A7, P.C7], Blocking = [P.D8],
            Moves = [new PossibleMove(P.A5, [P.A5], 0), new PossibleMove(P.C5, [P.C5], 0)]
        };
        yield return new TestCase
        {
            Source = P.D6, Captured = [P.C7, P.E7], Blocking = [P.B8, P.F8],
            Moves = [new PossibleMove(P.C5, [P.C5], 0), new PossibleMove(P.E5, [P.E5], 0)]
        };
        yield return new TestCase
        {
            Source = P.F6, Captured = [P.E7, P.G7], Blocking = [P.D8, P.H8],
            Moves = [new PossibleMove(P.E5, [P.E5], 0), new PossibleMove(P.G5, [P.G5], 0)]
        };
        yield return new TestCase
        {
            Source = P.H6, Captured = [P.G7], Blocking = [P.F8],
            Moves = [new PossibleMove(P.G5, [P.G5], 0)]
        };
    }
}