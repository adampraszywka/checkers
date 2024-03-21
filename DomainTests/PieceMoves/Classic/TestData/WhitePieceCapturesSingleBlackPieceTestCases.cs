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
            SourcePiece = new P(Position.R1, Position.A), CapturedPiece = new P(Position.R2, Position.B),
            Moves = new[] {new Move(new P(Position.R3, Position.C), new[] {new P(Position.R2, Position.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R1, Position.C), CapturedPiece = new P(Position.R2, Position.D),
            Moves = new[] {new Move(new P(Position.R3, Position.E), new[] {new P(Position.R2, Position.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R1, Position.C), CapturedPiece = new P(Position.R2, Position.B),
            Moves = new[] {new Move(new P(Position.R3, Position.A), new[] {new P(Position.R2, Position.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R1, Position.E), CapturedPiece = new P(Position.R2, Position.D),
            Moves = new[] {new Move(new P(Position.R3, Position.C), new[] {new P(Position.R2, Position.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R1, Position.E), CapturedPiece = new P(Position.R2, Position.F),
            Moves = new[] {new Move(new P(Position.R3, Position.G), new[] {new P(Position.R2, Position.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R1, Position.G), CapturedPiece = new P(Position.R2, Position.F),
            Moves = new[] {new Move(new P(Position.R3, Position.E), new[] {new P(Position.R2, Position.F)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R2, Position.B), CapturedPiece = new P(Position.R3, Position.C),
            Moves = new[] {new Move(new P(Position.R4, Position.D), new[] {new P(Position.R3, Position.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R2, Position.D), CapturedPiece = new P(Position.R3, Position.C),
            Moves = new[] {new Move(new P(Position.R4, Position.B), new[] {new P(Position.R3, Position.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R2, Position.D), CapturedPiece = new P(Position.R3, Position.E),
            Moves = new[] {new Move(new P(Position.R4, Position.F), new[] {new P(Position.R3, Position.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R2, Position.F), CapturedPiece = new P(Position.R3, Position.E),
            Moves = new[] {new Move(new P(Position.R4, Position.D), new[] {new P(Position.R3, Position.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R2, Position.F), CapturedPiece = new P(Position.R3, Position.G),
            Moves = new[] {new Move(new P(Position.R4, Position.H), new[] {new P(Position.R3, Position.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R2, Position.H), CapturedPiece = new P(Position.R3, Position.G),
            Moves = new[] {new Move(new P(Position.R4, Position.F), new[] {new P(Position.R3, Position.G)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R3, Position.A), CapturedPiece = new P(Position.R4, Position.B),
            Moves = new[] {new Move(new P(Position.R5, Position.C), new[] {new P(Position.R4, Position.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R3, Position.C), CapturedPiece = new P(Position.R4, Position.B),
            Moves = new[] {new Move(new P(Position.R5, Position.A), new[] {new P(Position.R4, Position.B)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R3, Position.C), CapturedPiece = new P(Position.R4, Position.D),
            Moves = new[] {new Move(new P(Position.R5, Position.E), new[] {new P(Position.R4, Position.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R3, Position.E), CapturedPiece = new P(Position.R4, Position.D),
            Moves = new[] {new Move(new P(Position.R5, Position.C), new[] {new P(Position.R4, Position.D)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R3, Position.E), CapturedPiece = new P(Position.R4, Position.F),
            Moves = new[] {new Move(new P(Position.R5, Position.G), new[] {new P(Position.R4, Position.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R3, Position.G), CapturedPiece = new P(Position.R4, Position.F),
            Moves = new[] {new Move(new P(Position.R5, Position.E), new[] {new P(Position.R4, Position.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R4, Position.B), CapturedPiece = new P(Position.R5, Position.C),
            Moves = new[] {new Move(new P(Position.R6, Position.D), new[] {new P(Position.R5, Position.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R4, Position.D), CapturedPiece = new P(Position.R5, Position.C),
            Moves = new[] {new Move(new P(Position.R6, Position.B), new[] {new P(Position.R5, Position.C)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R4, Position.D), CapturedPiece = new P(Position.R5, Position.E),
            Moves = new[] {new Move(new P(Position.R6, Position.F), new[] {new P(Position.R5, Position.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R4, Position.F), CapturedPiece = new P(Position.R5, Position.E),
            Moves = new[] {new Move(new P(Position.R6, Position.D), new[] {new P(Position.R5, Position.E)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R4, Position.F), CapturedPiece = new P(Position.R5, Position.G),
            Moves = new[] {new Move(new P(Position.R6, Position.H), new[] {new P(Position.R5, Position.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R4, Position.H), CapturedPiece = new P(Position.R5, Position.G),
            Moves = new[] {new Move(new P(Position.R6, Position.F), new[] {new P(Position.R5, Position.G)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R5, Position.A), CapturedPiece = new P(Position.R6, Position.B),
            Moves = new[] {new Move(new P(Position.R7, Position.C), new[] {new P(Position.R6, Position.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R5, Position.C), CapturedPiece = new P(Position.R6, Position.B),
            Moves = new[] {new Move(new P(Position.R7, Position.A), new[] {new P(Position.R6, Position.B)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R5, Position.C), CapturedPiece = new P(Position.R6, Position.D),
            Moves = new[] {new Move(new P(Position.R7, Position.E), new[] {new P(Position.R6, Position.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R5, Position.E), CapturedPiece = new P(Position.R6, Position.D),
            Moves = new[] {new Move(new P(Position.R7, Position.C), new[] {new P(Position.R6, Position.D)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R5, Position.E), CapturedPiece = new P(Position.R6, Position.F),
            Moves = new[] {new Move(new P(Position.R7, Position.G), new[] {new P(Position.R6, Position.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R5, Position.G), CapturedPiece = new P(Position.R6, Position.F),
            Moves = new[] {new Move(new P(Position.R7, Position.E), new[] {new P(Position.R6, Position.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R6, Position.B), CapturedPiece = new P(Position.R7, Position.C),
            Moves = new[] {new Move(new P(Position.R8, Position.D), new[] {new P(Position.R7, Position.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R6, Position.D), CapturedPiece = new P(Position.R7, Position.C),
            Moves = new[] {new Move(new P(Position.R8, Position.B), new[] {new P(Position.R7, Position.C)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R6, Position.D), CapturedPiece = new P(Position.R7, Position.E),
            Moves = new[] {new Move(new P(Position.R8, Position.F), new[] {new P(Position.R7, Position.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R6, Position.F), CapturedPiece = new P(Position.R7, Position.E),
            Moves = new[] {new Move(new P(Position.R8, Position.D), new[] {new P(Position.R7, Position.E)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R6, Position.F), CapturedPiece = new P(Position.R7, Position.G),
            Moves = new[] {new Move(new P(Position.R8, Position.H), new[] {new P(Position.R7, Position.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(Position.R6, Position.H), CapturedPiece = new P(Position.R7, Position.G),
            Moves = new[] {new Move(new P(Position.R8, Position.F), new[] {new P(Position.R7, Position.G)}, 1)}
        };
    }
}