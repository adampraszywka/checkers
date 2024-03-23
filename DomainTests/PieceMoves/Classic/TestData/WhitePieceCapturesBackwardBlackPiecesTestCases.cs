using System.Collections;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhitePieceCapturesBackwardBlackPiecesTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.C), CapturedPieces = new[] {new P(P.R2, P.B), new P(P.R2, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R1, P.A), new[] {new P(P.R2, P.B)}, 1),
                new Move(new P(P.R1, P.E), new[] {new P(P.R2, P.D)}, 1)
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPieces = new[] {new P(P.R2, P.D), new P(P.R2, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R1, P.C), new[] {new P(P.R2, P.D)}, 1),
                new Move(new P(P.R1, P.G), new[] {new P(P.R2, P.F)}, 1)
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.G), CapturedPieces = new[] {new P(P.R2, P.F), new P(P.R2, P.H)},
            Moves = new[]
            {
                new Move(new P(P.R1, P.E), new[] {new P(P.R2, P.F)}, 1),
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.B), CapturedPieces = new[] {new P(P.R3, P.A), new P(P.R3, P.C)},
            Moves = new[] {new Move(new P(P.R2, P.D), new[] {new P(P.R3, P.C)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.D), CapturedPieces = new[] {new P(P.R3, P.C), new P(P.R3, P.E)},
            Moves = new[]
            {
                new Move(new P(P.R2, P.B), new[] {new P(P.R3, P.C)}, 1),
                new Move(new P(P.R2, P.F), new[] {new P(P.R3, P.E)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.F), CapturedPieces = new[] {new P(P.R3, P.E), new P(P.R3, P.G)},
            Moves = new[]
            {
                new Move(new P(P.R2, P.D), new[] {new P(P.R3, P.E)}, 1),
                new Move(new P(P.R2, P.H), new[] {new P(P.R3, P.G)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.H), CapturedPieces = new[] {new P(P.R3, P.G)},
            Moves = new[] {new Move(new P(P.R2, P.F), new[] {new P(P.R3, P.G)}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.A), CapturedPieces = new[] {new P(P.R4, P.B)},
            Moves = new[] {new Move(new P(P.R3, P.C), new[] {new P(P.R4, P.B)}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.C), CapturedPieces = new[] {new P(P.R4, P.B), new P(P.R4, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R3, P.A), new[] {new P(P.R4, P.B)}, 1),
                new Move(new P(P.R3, P.E), new[] {new P(P.R4, P.D)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPieces = new[] {new P(P.R4, P.D), new P(P.R4, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R3, P.C), new[] {new P(P.R4, P.D)}, 1),
                new Move(new P(P.R3, P.G), new[] {new P(P.R4, P.F)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.G), CapturedPieces = new[] {new P(P.R4, P.F), new P(P.R4, P.H)},
            Moves = new[]
            {
                new Move(new P(P.R3, P.E), new[] {new P(P.R4, P.F)}, 1),
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.B), CapturedPieces = new[] {new P(P.R5, P.A), new P(P.R5, P.C)},
            Moves = new[] {new Move(new P(P.R4, P.D), new[] {new P(P.R5, P.C)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.D), CapturedPieces = new[] {new P(P.R5, P.C), new P(P.R5, P.E)},
            Moves = new[]
            {
                new Move(new P(P.R4, P.B), new[] {new P(P.R5, P.C)}, 1),
                new Move(new P(P.R4, P.F), new[] {new P(P.R5, P.E)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.F), CapturedPieces = new[] {new P(P.R5, P.E), new P(P.R5, P.G)},
            Moves = new[]
            {
                new Move(new P(P.R4, P.D), new[] {new P(P.R5, P.E)}, 1),
                new Move(new P(P.R4, P.H), new[] {new P(P.R5, P.G)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.H), CapturedPieces = new[] {new P(P.R5, P.G)},
            Moves = new[] {new Move(new P(P.R4, P.F), new[] {new P(P.R5, P.G)}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.A), CapturedPieces = new[] {new P(P.R6, P.B)},
            Moves = new[] {new Move(new P(P.R5, P.C), new[] {new P(P.R6, P.B)}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.C), CapturedPieces = new[] {new P(P.R6, P.B), new P(P.R6, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R5, P.A), new[] {new P(P.R6, P.B)}, 1),
                new Move(new P(P.R5, P.E), new[] {new P(P.R6, P.D)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.E), CapturedPieces = new[] {new P(P.R6, P.D), new P(P.R6, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R5, P.C), new[] {new P(P.R6, P.D)}, 1),
                new Move(new P(P.R5, P.G), new[] {new P(P.R6, P.F)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.G), CapturedPieces = new[] {new P(P.R6, P.F), new P(P.R6, P.H)},
            Moves = new[]
            {
                new Move(new P(P.R5, P.E), new[] {new P(P.R6, P.F)}, 1),
            }
        };
    }
}