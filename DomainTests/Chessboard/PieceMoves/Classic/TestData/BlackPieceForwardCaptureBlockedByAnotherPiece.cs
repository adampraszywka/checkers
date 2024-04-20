using System.Collections;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class BlackPieceForwardCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        //Forward
        yield return new PieceCaptureTestCase {Source = P.B8, Captured = [P.A7, P.C7], Blocking = [P.D6]};
        yield return new PieceCaptureTestCase {Source = P.D8, Captured = [P.C7, P.E7], Blocking = [P.B6, P.F6]};
        yield return new PieceCaptureTestCase {Source = P.F8, Captured = [P.E7, P.G7], Blocking = [P.D6, P.H6]};
        yield return new PieceCaptureTestCase {Source = P.H8, Captured = [P.G7], Blocking = [P.F6]};

        yield return new PieceCaptureTestCase {Source = P.A7, Captured = [P.B6], Blocking = [P.C5]};
        yield return new PieceCaptureTestCase {Source = P.C7, Captured = [P.B6, P.D6], Blocking = [P.A5, P.E5]};
        yield return new PieceCaptureTestCase {Source = P.E7, Captured = [P.D6, P.F6], Blocking = [P.C5, P.G5]};
        yield return new PieceCaptureTestCase {Source = P.G7, Captured = [P.F6, P.H6], Blocking = [P.E5]};

        yield return new PieceCaptureTestCase {Source = P.B6, Captured = [P.A5, P.C5], Blocking = [P.D4]};
        yield return new PieceCaptureTestCase {Source = P.D6, Captured = [P.C5, P.E5], Blocking = [P.B4, P.F4]};
        yield return new PieceCaptureTestCase {Source = P.F6, Captured = [P.E5, P.G5], Blocking = [P.D4, P.H4]};
        yield return new PieceCaptureTestCase {Source = P.H6, Captured = [P.G5], Blocking = [P.F4]};

        yield return new PieceCaptureTestCase {Source = P.A5, Captured = [P.B4], Blocking = [P.C3]};
        yield return new PieceCaptureTestCase {Source = P.C5, Captured = [P.B4, P.D4], Blocking = [P.A3, P.E3]};
        yield return new PieceCaptureTestCase {Source = P.E5, Captured = [P.D4, P.F4], Blocking = [P.C3, P.G3]};
        yield return new PieceCaptureTestCase {Source = P.G5, Captured = [P.F4, P.H4], Blocking = [P.E3]};

        yield return new PieceCaptureTestCase {Source = P.B4, Captured = [P.A3, P.C3], Blocking = [P.D2]};
        yield return new PieceCaptureTestCase {Source = P.D4, Captured = [P.C3, P.E3], Blocking = [P.B2, P.F2]};
        yield return new PieceCaptureTestCase {Source = P.F4, Captured = [P.E3, P.G3], Blocking = [P.D2, P.H2]};
        yield return new PieceCaptureTestCase {Source = P.H4, Captured = [P.G3], Blocking = [P.F2]};

        yield return new PieceCaptureTestCase {Source = P.A3, Captured = [P.B2], Blocking = [P.C1]};
        yield return new PieceCaptureTestCase {Source = P.C3, Captured = [P.B2, P.D2], Blocking = [P.A1, P.E1]};
        yield return new PieceCaptureTestCase {Source = P.E3, Captured = [P.D2, P.F2], Blocking = [P.C1, P.G1]};
        yield return new PieceCaptureTestCase {Source = P.G3, Captured = [P.F2, P.H2], Blocking = [P.E1]};
    }
}