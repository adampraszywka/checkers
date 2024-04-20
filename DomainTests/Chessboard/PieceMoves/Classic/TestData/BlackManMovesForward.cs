using System.Collections;
using Domain.Chessboard.PieceMoves;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class BlackManMovesForward : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        // Row 8
        yield return new PieceCaptureTestCase {SourcePiece = P.B8, Moves = [new PossibleMove(P.A7, [P.A7], 0), new PossibleMove(P.C7, [P.C7], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.D8, Moves = [new PossibleMove(P.C7, [P.C7], 0), new PossibleMove(P.E7, [P.E7], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.F8, Moves = [new PossibleMove(P.E7, [P.E7], 0), new PossibleMove(P.G7, [P.G7], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.H8, Moves = [new PossibleMove(P.G7, [P.G7], 0)]};

        // Row 7
        yield return new PieceCaptureTestCase {SourcePiece = P.A7, Moves = [new PossibleMove(P.B6, [P.B6], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.C7, Moves = [new PossibleMove(P.B6, [P.B6], 0), new PossibleMove(P.D6, [P.D6], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.E7, Moves = [new PossibleMove(P.D6, [P.D6], 0), new PossibleMove(P.F6, [P.F6], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.G7, Moves = [new PossibleMove(P.F6, [P.F6], 0), new PossibleMove(P.H6, [P.H6], 0)]};

        // Row 6
        yield return new PieceCaptureTestCase {SourcePiece = P.B6, Moves = [new PossibleMove(P.A5, [P.A5], 0), new PossibleMove(P.C5, [P.C5], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.D6, Moves = [new PossibleMove(P.C5, [P.C5], 0), new PossibleMove(P.E5, [P.E5], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.F6, Moves = [new PossibleMove(P.E5, [P.E5], 0), new PossibleMove(P.G5, [P.G5], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.H6, Moves = [new PossibleMove(P.G5, [P.G5], 0)]};

        // Row 5
        yield return new PieceCaptureTestCase {SourcePiece = P.A5, Moves = [new PossibleMove(P.B4, [P.B4], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.C5, Moves = [new PossibleMove(P.B4, [P.B4], 0), new PossibleMove(P.D4, [P.D4], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.E5, Moves = [new PossibleMove(P.D4, [P.D4], 0), new PossibleMove(P.F4, [P.F4], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.G5, Moves = [new PossibleMove(P.F4, [P.F4], 0), new PossibleMove(P.H4, [P.H4], 0)]};

        // Row 4
        yield return new PieceCaptureTestCase {SourcePiece = P.B4, Moves = [new PossibleMove(P.A3, [P.A3], 0), new PossibleMove(P.C3, [P.C3], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.D4, Moves = [new PossibleMove(P.C3, [P.C3], 0), new PossibleMove(P.E3, [P.E3], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.F4, Moves = [new PossibleMove(P.E3, [P.E3], 0), new PossibleMove(P.G3, [P.G3], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.H4, Moves = [new PossibleMove(P.G3, [P.G3], 0)]};

        // Row 3
        yield return new PieceCaptureTestCase {SourcePiece = P.A3, Moves = [new PossibleMove(P.B2, [P.B2], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.C3, Moves = [new PossibleMove(P.B2, [P.B2], 0), new PossibleMove(P.D2, [P.D2], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.E3, Moves = [new PossibleMove(P.D2, [P.D2], 0), new PossibleMove(P.F2, [P.F2], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.G3, Moves = [new PossibleMove(P.F2, [P.F2], 0), new PossibleMove(P.H2, [P.H2], 0)]};

        // Row 2
        yield return new PieceCaptureTestCase {SourcePiece = P.B2, Moves = [new PossibleMove(P.A1, [P.A1], 0), new PossibleMove(P.C1, [P.C1], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.D2, Moves = [new PossibleMove(P.C1, [P.C1], 0), new PossibleMove(P.E1, [P.E1], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.F2, Moves = [new PossibleMove(P.E1, [P.E1], 0), new PossibleMove(P.G1, [P.G1], 0)]};
        yield return new PieceCaptureTestCase {SourcePiece = P.H2, Moves = [new PossibleMove(P.G1, [P.G1], 0)]};

        // Row 1
        yield return new PieceCaptureTestCase {SourcePiece = P.A1, Moves = []}; // No moves since it's at the edge
        yield return new PieceCaptureTestCase {SourcePiece = P.C1, Moves = []}; // No moves
        yield return new PieceCaptureTestCase {SourcePiece = P.E1, Moves = []}; // No moves
        yield return new PieceCaptureTestCase {SourcePiece = P.G1, Moves = []}; // No moves;
    }
}