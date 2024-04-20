using System.Collections;
using Domain.Chessboard.PieceMoves;
using P = Domain.Chessboard.Position;
using TestCase = DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto.PieceCaptureTestCase;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class WhitePieceBackwardCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCase
        {
            Source = P.A7, Captured = [P.B6], Blocking = [P.C5],
            Moves = [new PossibleMove(P.B8, [P.B8], 0)]
        };
        yield return new TestCase
        {
            Source = P.C7, Captured = [P.B6, P.D6], Blocking = [P.A5, P.E5],
            Moves = [new PossibleMove(P.B8, [P.B8], 0), new PossibleMove(P.D8, [P.D8], 0)]
        };
        yield return new TestCase
        {
            Source = P.E7, Captured = [P.D6, P.F6], Blocking = [P.C5, P.G5],
            Moves = [new PossibleMove(P.D8, [P.D8], 0), new PossibleMove(P.F8, [P.F8], 0)]
        };
        yield return new TestCase
        {
            Source = P.G7, Captured = [P.F6, P.H6], Blocking = [P.E5],
            Moves = [new PossibleMove(P.F8, [P.F8], 0), new PossibleMove(P.H8, [P.H8], 0)]
        };

        yield return new TestCase
        {
            Source = P.B6, Captured = [P.A5, P.C5], Blocking = [P.D4],
            Moves = [new PossibleMove(P.A7, [P.A7], 0), new PossibleMove(P.C7, [P.C7], 0)]
        };
        yield return new TestCase
        {
            Source = P.D6, Captured = [P.C5, P.E5], Blocking = [P.B4, P.F4],
            Moves = [new PossibleMove(P.C7, [P.C7], 0), new PossibleMove(P.E7, [P.E7], 0)]
        };
        yield return new TestCase
        {
            Source = P.F6, Captured = [P.E5, P.G5], Blocking = [P.D4, P.H4],
            Moves = [new PossibleMove(P.E7, [P.E7], 0), new PossibleMove(P.G7, [P.G7], 0)]
        };
        yield return new TestCase
        {
            Source = P.H6, Captured = [P.G5], Blocking = [P.F4],
            Moves = [new PossibleMove(P.G7, [P.G7], 0)]
        };

        yield return new TestCase
        {
            Source = P.A5, Captured = [P.B4], Blocking = [P.C3],
            Moves = [new PossibleMove(P.B6, [P.B6], 0)]
        };
        yield return new TestCase
        {
            Source = P.C5, Captured = [P.B4, P.D4], Blocking = [P.A3, P.E3],
            Moves = [new PossibleMove(P.B6, [P.B6], 0), new PossibleMove(P.D6, [P.D6], 0)]
        };
        yield return new TestCase
        {
            Source = P.E5, Captured = [P.D4, P.F4], Blocking = [P.C3, P.G3],
            Moves = [new PossibleMove(P.D6, [P.D6], 0), new PossibleMove(P.F6, [P.F6], 0)]
        };
        yield return new TestCase
        {
            Source = P.G5, Captured = [P.F4, P.H4], Blocking = [P.E3],
            Moves = [new PossibleMove(P.F6, [P.F6], 0), new PossibleMove(P.H6, [P.H6], 0)]
        };

        yield return new TestCase
        {
            Source = P.B4, Captured = [P.A3, P.C3], Blocking = [P.D2],
            Moves = [new PossibleMove(P.A5, [P.A5], 0), new PossibleMove(P.C5, [P.C5], 0)]
        };
        yield return new TestCase
        {
            Source = P.D4, Captured = [P.C3, P.E3], Blocking = [P.B2, P.F2],
            Moves = [new PossibleMove(P.C5, [P.C5], 0), new PossibleMove(P.E5, [P.E5], 0)]
        };
        yield return new TestCase
        {
            Source = P.F4, Captured = [P.E3, P.G3], Blocking = [P.D2, P.H2],
            Moves = [new PossibleMove(P.E5, [P.E5], 0), new PossibleMove(P.G5, [P.G5], 0)]
        };
        yield return new TestCase
        {
            Source = P.H4, Captured = [P.G3], Blocking = [P.F2],
            Moves = [new PossibleMove(P.G5, [P.G5], 0)]
        };
    }
}