using System.Collections;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class WhitePieceForwardCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        //Forward
        yield return new PieceCaptureTestCase {Source = P.A1, Captured = new[] {P.B2}, Blocking = new[] {P.C3}};
        yield return new PieceCaptureTestCase {Source = P.C1, Captured = new[] {P.B2, P.D2}, Blocking = new[] {P.A3, P.E3}};
        yield return new PieceCaptureTestCase {Source = P.E1, Captured = new[] {P.D2, P.F2}, Blocking = new[] {P.C3, P.G3}};
        yield return new PieceCaptureTestCase {Source = P.G1, Captured = new[] {P.F2, P.H2}, Blocking = new[] {P.E3}};
        yield return new PieceCaptureTestCase {Source = P.B2, Captured = new[] {P.A3, P.C3}, Blocking = new[] {P.D4}};
        yield return new PieceCaptureTestCase {Source = P.D2, Captured = new[] {P.C3, P.E3}, Blocking = new[] {P.B4, P.F4}};
        yield return new PieceCaptureTestCase {Source = P.F2, Captured = new[] {P.E3, P.G3}, Blocking = new[] {P.D4, P.H4}};
        yield return new PieceCaptureTestCase {Source = P.H2, Captured = new[] {P.G3}, Blocking = new[] {P.F4}};
        yield return new PieceCaptureTestCase {Source = P.A3, Captured = new[] {P.B4}, Blocking = new[] {P.C5}};
        yield return new PieceCaptureTestCase {Source = P.C3, Captured = new[] {P.B4, P.D4}, Blocking = new[] {P.A5, P.E5}};
        yield return new PieceCaptureTestCase {Source = P.E3, Captured = new[] {P.D4, P.F4}, Blocking = new[] {P.C5, P.G5}};
        yield return new PieceCaptureTestCase {Source = P.G3, Captured = new[] {P.F4, P.H4}, Blocking = new[] {P.E5}};
        yield return new PieceCaptureTestCase {Source = P.B4, Captured = new[] {P.A5, P.C5}, Blocking = new[] {P.D6}};
        yield return new PieceCaptureTestCase {Source = P.D4, Captured = new[] {P.C5, P.E5}, Blocking = new[] {P.B6, P.F6}};
        yield return new PieceCaptureTestCase {Source = P.F4, Captured = new[] {P.E5, P.G5}, Blocking = new[] {P.D6, P.H6}};
        yield return new PieceCaptureTestCase {Source = P.H4, Captured = new[] {P.G5}, Blocking = new[] {P.F6}};
        yield return new PieceCaptureTestCase {Source = P.A5, Captured = new[] {P.B6}, Blocking = new[] {P.C7}};
        yield return new PieceCaptureTestCase {Source = P.C5, Captured = new[] {P.B6, P.D6}, Blocking = new[] {P.A7, P.E7}};
        yield return new PieceCaptureTestCase {Source = P.E5, Captured = new[] {P.D6, P.F6}, Blocking = new[] {P.C7, P.G7}};
        yield return new PieceCaptureTestCase {Source = P.G5, Captured = new[] {P.F6, P.H6}, Blocking = new[] {P.E7}};
        yield return new PieceCaptureTestCase {Source = P.B6, Captured = new[] {P.A7, P.C7}, Blocking = new[] {P.D8}};
        yield return new PieceCaptureTestCase {Source = P.D6, Captured = new[] {P.C7, P.E7}, Blocking = new[] {P.B8, P.F8}};
        yield return new PieceCaptureTestCase {Source = P.F6, Captured = new[] {P.E7, P.G7}, Blocking = new[] {P.D8, P.H8}};
        yield return new PieceCaptureTestCase {Source = P.H6, Captured = new[] {P.G7}, Blocking = new[] {P.F8}};
    }
}