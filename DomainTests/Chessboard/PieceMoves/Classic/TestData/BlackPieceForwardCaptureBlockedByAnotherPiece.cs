using System.Collections;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class BlackPieceForwardCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        //Forward
        yield return new PieceCaptureTestCase {SourcePiece = P.B8, CapturedPieces = [P.A7, P.C7], BlockingPieces = [P.D6]};
        yield return new PieceCaptureTestCase {SourcePiece = P.D8, CapturedPieces = [P.C7, P.E7], BlockingPieces = [P.B6, P.F6]};
        yield return new PieceCaptureTestCase {SourcePiece = P.F8, CapturedPieces = [P.E7, P.G7], BlockingPieces = [P.D6, P.H6]};
        yield return new PieceCaptureTestCase {SourcePiece = P.H8, CapturedPieces = [P.G7], BlockingPieces = [P.F6]};

        yield return new PieceCaptureTestCase {SourcePiece = P.A7, CapturedPieces = [P.B6], BlockingPieces = [P.C5]};
        yield return new PieceCaptureTestCase {SourcePiece = P.C7, CapturedPieces = [P.B6, P.D6], BlockingPieces = [P.A5, P.E5]};
        yield return new PieceCaptureTestCase {SourcePiece = P.E7, CapturedPieces = [P.D6, P.F6], BlockingPieces = [P.C5, P.G5]};
        yield return new PieceCaptureTestCase {SourcePiece = P.G7, CapturedPieces = [P.F6, P.H6], BlockingPieces = [P.E5]};

        yield return new PieceCaptureTestCase {SourcePiece = P.B6, CapturedPieces = [P.A5, P.C5], BlockingPieces = [P.D4]};
        yield return new PieceCaptureTestCase {SourcePiece = P.D6, CapturedPieces = [P.C5, P.E5], BlockingPieces = [P.B4, P.F4]};
        yield return new PieceCaptureTestCase {SourcePiece = P.F6, CapturedPieces = [P.E5, P.G5], BlockingPieces = [P.D4, P.H4]};
        yield return new PieceCaptureTestCase {SourcePiece = P.H6, CapturedPieces = [P.G5], BlockingPieces = [P.F4]};

        yield return new PieceCaptureTestCase {SourcePiece = P.A5, CapturedPieces = [P.B4], BlockingPieces = [P.C3]};
        yield return new PieceCaptureTestCase {SourcePiece = P.C5, CapturedPieces = [P.B4, P.D4], BlockingPieces = [P.A3, P.E3]};
        yield return new PieceCaptureTestCase {SourcePiece = P.E5, CapturedPieces = [P.D4, P.F4], BlockingPieces = [P.C3, P.G3]};
        yield return new PieceCaptureTestCase {SourcePiece = P.G5, CapturedPieces = [P.F4, P.H4], BlockingPieces = [P.E3]};

        yield return new PieceCaptureTestCase {SourcePiece = P.B4, CapturedPieces = [P.A3, P.C3], BlockingPieces = [P.D2]};
        yield return new PieceCaptureTestCase {SourcePiece = P.D4, CapturedPieces = [P.C3, P.E3], BlockingPieces = [P.B2, P.F2]};
        yield return new PieceCaptureTestCase {SourcePiece = P.F4, CapturedPieces = [P.E3, P.G3], BlockingPieces = [P.D2, P.H2]};
        yield return new PieceCaptureTestCase {SourcePiece = P.H4, CapturedPieces = [P.G3], BlockingPieces = [P.F2]};

        yield return new PieceCaptureTestCase {SourcePiece = P.A3, CapturedPieces = [P.B2], BlockingPieces = [P.C1]};
        yield return new PieceCaptureTestCase {SourcePiece = P.C3, CapturedPieces = [P.B2, P.D2], BlockingPieces = [P.A1, P.E1]};
        yield return new PieceCaptureTestCase {SourcePiece = P.E3, CapturedPieces = [P.D2, P.F2], BlockingPieces = [P.C1, P.G1]};
        yield return new PieceCaptureTestCase {SourcePiece = P.G3, CapturedPieces = [P.F2, P.H2], BlockingPieces = [P.E1]};
    }
}