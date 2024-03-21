using System.Collections;
using Domain;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhitePieceCapturesSingleBlackPieceTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        //Row1
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.A), CapturedPiece = new P(P.R2, P.B),
            Moves = new[] {new Move(new P(P.R3, P.C), new[] {new P(P.R2, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.C), CapturedPiece = new P(P.R2, P.D),
            Moves = new[] {new Move(new P(P.R3, P.E), new[] {new P(P.R2, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.C), CapturedPiece = new P(P.R2, P.B),
            Moves = new[] {new Move(new P(P.R3, P.A), new[] {new P(P.R2, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.E), CapturedPiece = new P(P.R2, P.D),
            Moves = new[] {new Move(new P(P.R3, P.C), new[] {new P(P.R2, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.E), CapturedPiece = new P(P.R2, P.F),
            Moves = new[] {new Move(new P(P.R3, P.G), new[] {new P(P.R2, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.G), CapturedPiece = new P(P.R2, P.F),
            Moves = new[] {new Move(new P(P.R3, P.E), new[] {new P(P.R2, P.F)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.B), CapturedPiece = new P(P.R3, P.C),
            Moves = new[] {new Move(new P(P.R4, P.D), new[] {new P(P.R3, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.D), CapturedPiece = new P(P.R3, P.C),
            Moves = new[] {new Move(new P(P.R4, P.B), new[] {new P(P.R3, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.D), CapturedPiece = new P(P.R3, P.E),
            Moves = new[] {new Move(new P(P.R4, P.F), new[] {new P(P.R3, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.F), CapturedPiece = new P(P.R3, P.E),
            Moves = new[] {new Move(new P(P.R4, P.D), new[] {new P(P.R3, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.F), CapturedPiece = new P(P.R3, P.G),
            Moves = new[] {new Move(new P(P.R4, P.H), new[] {new P(P.R3, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.H), CapturedPiece = new P(P.R3, P.G),
            Moves = new[] {new Move(new P(P.R4, P.F), new[] {new P(P.R3, P.G)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.A), CapturedPiece = new P(P.R4, P.B),
            Moves = new[] {new Move(new P(P.R5, P.C), new[] {new P(P.R4, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.C), CapturedPiece = new P(P.R4, P.B),
            Moves = new[] {new Move(new P(P.R5, P.A), new[] {new P(P.R4, P.B)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.C), CapturedPiece = new P(P.R4, P.D),
            Moves = new[] {new Move(new P(P.R5, P.E), new[] {new P(P.R4, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPiece = new P(P.R4, P.D),
            Moves = new[] {new Move(new P(P.R5, P.C), new[] {new P(P.R4, P.D)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPiece = new P(P.R4, P.F),
            Moves = new[] {new Move(new P(P.R5, P.G), new[] {new P(P.R4, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.G), CapturedPiece = new P(P.R4, P.F),
            Moves = new[] {new Move(new P(P.R5, P.E), new[] {new P(P.R4, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.B), CapturedPiece = new P(P.R5, P.C),
            Moves = new[] {new Move(new P(P.R6, P.D), new[] {new P(P.R5, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.D), CapturedPiece = new P(P.R5, P.C),
            Moves = new[] {new Move(new P(P.R6, P.B), new[] {new P(P.R5, P.C)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.D), CapturedPiece = new P(P.R5, P.E),
            Moves = new[] {new Move(new P(P.R6, P.F), new[] {new P(P.R5, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.F), CapturedPiece = new P(P.R5, P.E),
            Moves = new[] {new Move(new P(P.R6, P.D), new[] {new P(P.R5, P.E)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.F), CapturedPiece = new P(P.R5, P.G),
            Moves = new[] {new Move(new P(P.R6, P.H), new[] {new P(P.R5, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.H), CapturedPiece = new P(P.R5, P.G),
            Moves = new[] {new Move(new P(P.R6, P.F), new[] {new P(P.R5, P.G)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.A), CapturedPiece = new P(P.R6, P.B),
            Moves = new[] {new Move(new P(P.R7, P.C), new[] {new P(P.R6, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.C), CapturedPiece = new P(P.R6, P.B),
            Moves = new[] {new Move(new P(P.R7, P.A), new[] {new P(P.R6, P.B)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.C), CapturedPiece = new P(P.R6, P.D),
            Moves = new[] {new Move(new P(P.R7, P.E), new[] {new P(P.R6, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPiece = new P(P.R6, P.D),
            Moves = new[] {new Move(new P(P.R7, P.C), new[] {new P(P.R6, P.D)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPiece = new P(P.R6, P.F),
            Moves = new[] {new Move(new P(P.R7, P.G), new[] {new P(P.R6, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.G), CapturedPiece = new P(P.R6, P.F),
            Moves = new[] {new Move(new P(P.R7, P.E), new[] {new P(P.R6, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.B), CapturedPiece = new P(P.R7, P.C),
            Moves = new[] {new Move(new P(P.R8, P.D), new[] {new P(P.R7, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.D), CapturedPiece = new P(P.R7, P.C),
            Moves = new[] {new Move(new P(P.R8, P.B), new[] {new P(P.R7, P.C)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.D), CapturedPiece = new P(P.R7, P.E),
            Moves = new[] {new Move(new P(P.R8, P.F), new[] {new P(P.R7, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.F), CapturedPiece = new P(P.R7, P.E),
            Moves = new[] {new Move(new P(P.R8, P.D), new[] {new P(P.R7, P.E)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.F), CapturedPiece = new P(P.R7, P.G),
            Moves = new[] {new Move(new P(P.R8, P.H), new[] {new P(P.R7, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.H), CapturedPiece = new P(P.R7, P.G),
            Moves = new[] {new Move(new P(P.R8, P.F), new[] {new P(P.R7, P.G)}, 1)}
        };
    }
}