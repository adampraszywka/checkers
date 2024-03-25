using System.Collections;
using P = Domain.Position;
using TestCase = DomainTests.PieceMoves.Classic.TestData.PieceCaptureBlockTestCase;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhitePieceCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        //Forward
        yield return new TestCase {SourcePiece = P.A1, CapturedPieces = new[] {P.B2}, BlockingPieces = new[] {P.C3}};
        yield return new TestCase {SourcePiece = P.C1, CapturedPieces = new[] {P.B2, P.D2}, BlockingPieces = new[] {P.A3, P.E3}};
        yield return new TestCase {SourcePiece = P.E1, CapturedPieces = new[] {P.D2, P.F2}, BlockingPieces = new[] {P.C3, P.G3}};
        yield return new TestCase {SourcePiece = P.G1, CapturedPieces = new[] {P.F2, P.H2}, BlockingPieces = new[] {P.E3}};
        yield return new TestCase {SourcePiece = P.B2, CapturedPieces = new[] {P.A3, P.C3}, BlockingPieces = new[] {P.D4}};
        yield return new TestCase {SourcePiece = P.D2, CapturedPieces = new[] {P.C3, P.E3}, BlockingPieces = new[] {P.B4, P.F4}};
        yield return new TestCase {SourcePiece = P.F2, CapturedPieces = new[] {P.E3, P.G3}, BlockingPieces = new[] {P.D4, P.H4}};
        yield return new TestCase {SourcePiece = P.H2, CapturedPieces = new[] {P.G3}, BlockingPieces = new[] {P.F4}};
        yield return new TestCase {SourcePiece = P.A3, CapturedPieces = new[] {P.B4}, BlockingPieces = new[] {P.C5}};
        yield return new TestCase {SourcePiece = P.C3, CapturedPieces = new[] {P.B4, P.D4}, BlockingPieces = new[] {P.A5, P.E5}};
        yield return new TestCase {SourcePiece = P.E3, CapturedPieces = new[] {P.D4, P.F4}, BlockingPieces = new[] {P.C5, P.G5}};
        yield return new TestCase {SourcePiece = P.G3, CapturedPieces = new[] {P.F4, P.H4}, BlockingPieces = new[] {P.E5}};
        yield return new TestCase {SourcePiece = P.B4, CapturedPieces = new[] {P.A5, P.C5}, BlockingPieces = new[] {P.D6}};
        yield return new TestCase {SourcePiece = P.D4, CapturedPieces = new[] {P.C5, P.E5}, BlockingPieces = new[] {P.B6, P.F6}};
        yield return new TestCase {SourcePiece = P.F4, CapturedPieces = new[] {P.E5, P.G5}, BlockingPieces = new[] {P.D6, P.H6}};
        yield return new TestCase {SourcePiece = P.H4, CapturedPieces = new[] {P.G5}, BlockingPieces = new[] {P.F6}};
        yield return new TestCase {SourcePiece = P.A5, CapturedPieces = new[] {P.B6}, BlockingPieces = new[] {P.C7}};
        yield return new TestCase {SourcePiece = P.C5, CapturedPieces = new[] {P.B6, P.D6}, BlockingPieces = new[] {P.A7, P.E7}};
        yield return new TestCase {SourcePiece = P.E5, CapturedPieces = new[] {P.D6, P.F6}, BlockingPieces = new[] {P.C7, P.G7}};
        yield return new TestCase {SourcePiece = P.G5, CapturedPieces = new[] {P.F6, P.H6}, BlockingPieces = new[] {P.E7}};
        yield return new TestCase {SourcePiece = P.B6, CapturedPieces = new[] {P.A7, P.C7}, BlockingPieces = new[] {P.D8}};
        yield return new TestCase {SourcePiece = P.D6, CapturedPieces = new[] {P.C7, P.E7}, BlockingPieces = new[] {P.B8, P.F8}};
        yield return new TestCase {SourcePiece = P.F6, CapturedPieces = new[] {P.E7, P.G7}, BlockingPieces = new[] {P.D8, P.H8}};
        yield return new TestCase {SourcePiece = P.H6, CapturedPieces = new[] {P.G7}, BlockingPieces = new[] {P.F8}};
    }
}