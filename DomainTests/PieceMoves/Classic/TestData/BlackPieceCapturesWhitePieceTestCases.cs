using System.Collections;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class BlackPieceCapturesWhitePieceTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.B), CapturedPieces = new[] {new P(P.R7, P.C), new P(P.R7, P.A)},
            Moves = new[] {new Move(new P(P.R6, P.D), new[] {new P(P.R7, P.C)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.D), CapturedPieces = new[] {new P(P.R7, P.C)},
            Moves = new[] {new Move(new P(P.R6, P.B), new[] {new P(P.R7, P.C)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.D), CapturedPieces = new[] {new P(P.R7, P.E)},
            Moves = new[] {new Move(new P(P.R6, P.F), new[] {new P(P.R7, P.E)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.F), CapturedPieces = new[] {new P(P.R7, P.E)},
            Moves = new[] {new Move(new P(P.R6, P.D), new[] {new P(P.R7, P.E)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.F), CapturedPieces = new[] {new P(P.R7, P.G)},
            Moves = new[] {new Move(new P(P.R6, P.H), new[] {new P(P.R7, P.G)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.H), CapturedPieces = new[] {new P(P.R7, P.G)},
            Moves = new[] {new Move(new P(P.R6, P.F), new[] {new P(P.R7, P.G)}, 1)}
        };


        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.D), CapturedPieces = new[] {new P(P.R7, P.C), new P(P.R7, P.E)},
            Moves = new[]
            {
                new Move(new P(P.R6, P.B), new[] {new P(P.R7, P.C)}, 1),
                new Move(new P(P.R6, P.F), new[] {new P(P.R7, P.E)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R8, P.F), CapturedPieces = new[] {new P(P.R7, P.E), new P(P.R7, P.G)},
            Moves = new[]
            {
                new Move(new P(P.R6, P.D), new[] {new P(P.R7, P.E)}, 1),
                new Move(new P(P.R6, P.H), new[] {new P(P.R7, P.G)}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.A), CapturedPieces = new[] {new P(P.R6, P.B)},
            Moves = new[] {new Move(new P(P.R5, P.C), new[] {new P(P.R6, P.B)}, 1)}
        };

        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.C), CapturedPieces = new[] {new P(P.R6, P.B)},
            Moves = new[] {new Move(new P(P.R5, P.A), new[] {new P(P.R6, P.B)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.C), CapturedPieces = new[] {new P(P.R6, P.D)},
            Moves = new[] {new Move(new P(P.R5, P.E), new[] {new P(P.R6, P.D)}, 1)}
        };

        // Black piece on E7, capturing towards D6 or F6
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.E), CapturedPieces = new[] {new P(P.R6, P.D)},
            Moves = new[] {new Move(new P(P.R5, P.C), new[] {new P(P.R6, P.D)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.E), CapturedPieces = new[] {new P(P.R6, P.F)},
            Moves = new[] {new Move(new P(P.R5, P.G), new[] {new P(P.R6, P.F)}, 1)}
        };

        // Cases with multiple capturing options

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
            SourcePiece = new P(P.R6, P.B), CapturedPieces = new[] {new P(P.R5, P.C)},
            Moves = new[] {new Move(new P(P.R4, P.D), new[] {new P(P.R5, P.C)}, 1)}
        };

        // Black piece on D6, capturing towards C5 or E5
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.D), CapturedPieces = new[] {new P(P.R5, P.C)},
            Moves = new[] {new Move(new P(P.R4, P.B), new[] {new P(P.R5, P.C)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.D), CapturedPieces = new[] {new P(P.R5, P.E)},
            Moves = new[] {new Move(new P(P.R4, P.F), new[] {new P(P.R5, P.E)}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.B), CapturedPieces = new[] {new P(P.R5, P.A), new P(P.R5, P.C)},
            Moves = new[]
            {
                new Move(new P(P.R4, P.D), new[] {new P(P.R5, P.C)}, 1)
            }
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
            SourcePiece = new P(P.R5, P.C), CapturedPieces = new[] {new P(P.R4, P.B)},
            Moves = new[] {new Move(new P(P.R3, P.A), new[] {new P(P.R4, P.B)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.C), CapturedPieces = new[] {new P(P.R4, P.D)},
            Moves = new[] {new Move(new P(P.R3, P.E), new[] {new P(P.R4, P.D)}, 1)}
        };

        // Black piece on E5, capturing towards D4 or F4
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPieces = new[] {new P(P.R4, P.D)},
            Moves = new[] {new Move(new P(P.R3, P.C), new[] {new P(P.R4, P.D)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPieces = new[] {new P(P.R4, P.F)},
            Moves = new[] {new Move(new P(P.R3, P.G), new[] {new P(P.R4, P.F)}, 1)}
        };

        // Cases with multiple capturing options

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
            SourcePiece = new P(P.R4, P.B), CapturedPieces = new[] {new P(P.R3, P.C), new P(P.R3, P.A)},
            Moves = new[] {new Move(new P(P.R2, P.D), new[] {new P(P.R3, P.C)}, 1)}
        };

        // Black piece on D4, capturing towards C3 or E3
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.D), CapturedPieces = new[] {new P(P.R3, P.C)},
            Moves = new[] {new Move(new P(P.R2, P.B), new[] {new P(P.R3, P.C)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.D), CapturedPieces = new[] {new P(P.R3, P.E)},
            Moves = new[] {new Move(new P(P.R2, P.F), new[] {new P(P.R3, P.E)}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.B), CapturedPieces = new[] {new P(P.R3, P.A), new P(P.R3, P.C)},
            Moves = new[]
            {
                new Move(new P(P.R2, P.D), new[] {new P(P.R3, P.C)}, 1),
            }
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
            SourcePiece = new P(P.R3, P.C), CapturedPieces = new[] {new P(P.R2, P.B)},
            Moves = new[] {new Move(new P(P.R1, P.A), new[] {new P(P.R2, P.B)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.C), CapturedPieces = new[] {new P(P.R2, P.D)},
            Moves = new[] {new Move(new P(P.R1, P.E), new[] {new P(P.R2, P.D)}, 1)}
        };

        // Black piece on E3, capturing towards D2 or F2
        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPieces = new[] {new P(P.R2, P.D)},
            Moves = new[] {new Move(new P(P.R1, P.C), new[] {new P(P.R2, P.D)}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPieces = new[] {new P(P.R2, P.F)},
            Moves = new[] {new Move(new P(P.R1, P.G), new[] {new P(P.R2, P.F)}, 1)}
        };
        
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
    }
}