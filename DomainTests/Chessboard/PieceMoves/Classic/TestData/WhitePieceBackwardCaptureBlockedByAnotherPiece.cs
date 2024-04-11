using System.Collections;
using Domain.Chessboard.PieceMoves;
using P = Domain.Chessboard.Position;
using TestCase = DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto.PieceBackwardCaptureBlockTestCase;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class WhitePieceBackwardCaptureBlockedByAnotherPiece : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCase
        {
            SourcePiece = P.A7, CapturedPieces = [P.B6], BlockingPieces = [P.C5],
            Moves = [new PossibleMove(P.B8, [P.B8], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.C7, CapturedPieces = [P.B6, P.D6], BlockingPieces = [P.A5, P.E5],
            Moves = [new PossibleMove(P.B8, [P.B8], 0), new PossibleMove(P.D8, [P.D8], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.E7, CapturedPieces = [P.D6, P.F6], BlockingPieces = [P.C5, P.G5],
            Moves = [new PossibleMove(P.D8, [P.D8], 0), new PossibleMove(P.F8, [P.F8], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.G7, CapturedPieces = [P.F6, P.H6], BlockingPieces = [P.E5],
            Moves = [new PossibleMove(P.F8, [P.F8], 0), new PossibleMove(P.H8, [P.H8], 0)]
        };

        yield return new TestCase
        {
            SourcePiece = P.B6, CapturedPieces = [P.A5, P.C5], BlockingPieces = [P.D4],
            Moves = [new PossibleMove(P.A7, [P.A7], 0), new PossibleMove(P.C7, [P.C7], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.D6, CapturedPieces = [P.C5, P.E5], BlockingPieces = [P.B4, P.F4],
            Moves = [new PossibleMove(P.C7, [P.C7], 0), new PossibleMove(P.E7, [P.E7], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.F6, CapturedPieces = [P.E5, P.G5], BlockingPieces = [P.D4, P.H4],
            Moves = [new PossibleMove(P.E7, [P.E7], 0), new PossibleMove(P.G7, [P.G7], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.H6, CapturedPieces = [P.G5], BlockingPieces = [P.F4],
            Moves = [new PossibleMove(P.G7, [P.G7], 0)]
        };

        yield return new TestCase
        {
            SourcePiece = P.A5, CapturedPieces = [P.B4], BlockingPieces = [P.C3],
            Moves = [new PossibleMove(P.B6, [P.B6], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.C5, CapturedPieces = [P.B4, P.D4], BlockingPieces = [P.A3, P.E3],
            Moves = [new PossibleMove(P.B6, [P.B6], 0), new PossibleMove(P.D6, [P.D6], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.E5, CapturedPieces = [P.D4, P.F4], BlockingPieces = [P.C3, P.G3],
            Moves = [new PossibleMove(P.D6, [P.D6], 0), new PossibleMove(P.F6, [P.F6], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.G5, CapturedPieces = [P.F4, P.H4], BlockingPieces = [P.E3],
            Moves = [new PossibleMove(P.F6, [P.F6], 0), new PossibleMove(P.H6, [P.H6], 0)]
        };

        yield return new TestCase
        {
            SourcePiece = P.B4, CapturedPieces = [P.A3, P.C3], BlockingPieces = [P.D2],
            Moves = [new PossibleMove(P.A5, [P.A5], 0), new PossibleMove(P.C5, [P.C5], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.D4, CapturedPieces = [P.C3, P.E3], BlockingPieces = [P.B2, P.F2],
            Moves = [new PossibleMove(P.C5, [P.C5], 0), new PossibleMove(P.E5, [P.E5], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.F4, CapturedPieces = [P.E3, P.G3], BlockingPieces = [P.D2, P.H2],
            Moves = [new PossibleMove(P.E5, [P.E5], 0), new PossibleMove(P.G5, [P.G5], 0)]
        };
        yield return new TestCase
        {
            SourcePiece = P.H4, CapturedPieces = [P.G3], BlockingPieces = [P.F2],
            Moves = [new PossibleMove(P.G5, [P.G5], 0)]
        };
    }
}