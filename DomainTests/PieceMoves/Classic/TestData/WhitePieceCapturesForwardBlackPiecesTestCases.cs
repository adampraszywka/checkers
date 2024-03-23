using System.Collections;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhitePieceCapturesForwardBlackPiecesTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        //Row1
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.A), CapturedPieces = new[] {new P(P.R2, P.B)},
            Moves = new[] {new Move(new P(P.R3, P.C), new[] {new P(P.R2, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.C), CapturedPieces = new[] {new P(P.R2, P.D)},
            Moves = new[] {new Move(new P(P.R3, P.E), new[] {new P(P.R2, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.C), CapturedPieces = new[] {new P(P.R2, P.B)},
            Moves = new[] {new Move(new P(P.R3, P.A), new[] {new P(P.R2, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.E), CapturedPieces = new[] {new P(P.R2, P.D)},
            Moves = new[] {new Move(new P(P.R3, P.C), new[] {new P(P.R2, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.E), CapturedPieces = new[] {new P(P.R2, P.F)},
            Moves = new[] {new Move(new P(P.R3, P.G), new[] {new P(P.R2, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.G), CapturedPieces = new[] {new P(P.R2, P.F), new P(P.R2, P.H)},
            Moves = new[] {new Move(new P(P.R3, P.E), new[] {new P(P.R2, P.F)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.C), CapturedPieces = new[] {new P(P.R2, P.B), new P(P.R2, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R3, P.A), new[] {new P(P.R2, P.B)}, 1),
                new Move(new P(P.R3, P.E), new[] {new P(P.R2, P.D)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R1, P.E), CapturedPieces = new[] {new P(P.R2, P.D), new P(P.R2, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R3, P.C), new[] {new P(P.R2, P.D)}, 1),
                new Move(new P(P.R3, P.G), new[] {new P(P.R2, P.F)}, 1)
            }
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.B), CapturedPieces = new[] {new P(P.R3, P.C), new P(P.R3, P.A)},
            Moves = new[] {new Move(new P(P.R4, P.D), new[] {new P(P.R3, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.D), CapturedPieces = new[] {new P(P.R3, P.C)},
            Moves = new[] {new Move(new P(P.R4, P.B), new[] {new P(P.R3, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.D), CapturedPieces = new[] {new P(P.R3, P.E)},
            Moves = new[] {new Move(new P(P.R4, P.F), new[] {new P(P.R3, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.F), CapturedPieces = new[] {new P(P.R3, P.E)},
            Moves = new[] {new Move(new P(P.R4, P.D), new[] {new P(P.R3, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.F), CapturedPieces = new[] {new P(P.R3, P.G)},
            Moves = new[] {new Move(new P(P.R4, P.H), new[] {new P(P.R3, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.H), CapturedPieces = new[] {new P(P.R3, P.G)},
            Moves = new[] {new Move(new P(P.R4, P.F), new[] {new P(P.R3, P.G)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.C), CapturedPieces = new[] {new P(P.R3, P.B), new P(P.R3, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R4, P.A), new[] {new P(P.R3, P.B)}, 1),
                new Move(new P(P.R4, P.E), new[] {new P(P.R3, P.D)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R2, P.E), CapturedPieces = new[] {new P(P.R3, P.D), new P(P.R3, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R4, P.C), new[] {new P(P.R3, P.D)}, 1),
                new Move(new P(P.R4, P.G), new[] {new P(P.R3, P.F)}, 1)
            }
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.A), CapturedPieces = new[] {new P(P.R4, P.B)},
            Moves = new[] {new Move(new P(P.R5, P.C), new[] {new P(P.R4, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.C), CapturedPieces = new[] {new P(P.R4, P.B)},
            Moves = new[] {new Move(new P(P.R5, P.A), new[] {new P(P.R4, P.B)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.C), CapturedPieces = new[] {new P(P.R4, P.D)},
            Moves = new[] {new Move(new P(P.R5, P.E), new[] {new P(P.R4, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPieces = new[] {new P(P.R4, P.D)},
            Moves = new[] {new Move(new P(P.R5, P.C), new[] {new P(P.R4, P.D)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPieces = new[] {new P(P.R4, P.F), new P(P.R4, P.H)},
            Moves = new[] {new Move(new P(P.R5, P.G), new[] {new P(P.R4, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.G), CapturedPieces = new[] {new P(P.R4, P.F), new P(P.R4, P.F)},
            Moves = new[] {new Move(new P(P.R5, P.E), new[] {new P(P.R4, P.F)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.C), CapturedPieces = new[] {new P(P.R4, P.B), new P(P.R4, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R5, P.A), new[] {new P(P.R4, P.B)}, 1),
                new Move(new P(P.R5, P.E), new[] {new P(P.R4, P.D)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R3, P.E), CapturedPieces = new[] {new P(P.R4, P.D), new P(P.R4, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R5, P.C), new[] {new P(P.R4, P.D)}, 1),
                new Move(new P(P.R5, P.G), new[] {new P(P.R4, P.F)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.B), CapturedPieces = new[] {new P(P.R5, P.C), new P(P.R5, P.A)},
            Moves = new[] {new Move(new P(P.R6, P.D), new[] {new P(P.R5, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.D), CapturedPieces = new[] {new P(P.R5, P.C)},
            Moves = new[] {new Move(new P(P.R6, P.B), new[] {new P(P.R5, P.C)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.D), CapturedPieces = new[] {new P(P.R5, P.E)},
            Moves = new[] {new Move(new P(P.R6, P.F), new[] {new P(P.R5, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.F), CapturedPieces = new[] {new P(P.R5, P.E)},
            Moves = new[] {new Move(new P(P.R6, P.D), new[] {new P(P.R5, P.E)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.F), CapturedPieces = new[] {new P(P.R5, P.G)},
            Moves = new[] {new Move(new P(P.R6, P.H), new[] {new P(P.R5, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.H), CapturedPieces = new[] {new P(P.R5, P.G)},
            Moves = new[] {new Move(new P(P.R6, P.F), new[] {new P(P.R5, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.C), CapturedPieces = new[] {new P(P.R5, P.B), new P(P.R5, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R6, P.A), new[] {new P(P.R5, P.B)}, 1),
                new Move(new P(P.R6, P.E), new[] {new P(P.R5, P.D)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R4, P.E), CapturedPieces = new[] {new P(P.R5, P.D), new P(P.R5, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R6, P.C), new[] {new P(P.R5, P.D)}, 1),
                new Move(new P(P.R6, P.G), new[] {new P(P.R5, P.F)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.A), CapturedPieces = new[] {new P(P.R6, P.B)},
            Moves = new[] {new Move(new P(P.R7, P.C), new[] {new P(P.R6, P.B)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.C), CapturedPieces = new[] {new P(P.R6, P.B)},
            Moves = new[] {new Move(new P(P.R7, P.A), new[] {new P(P.R6, P.B)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.C), CapturedPieces = new[] {new P(P.R6, P.D)},
            Moves = new[] {new Move(new P(P.R7, P.E), new[] {new P(P.R6, P.D)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPieces = new[] {new P(P.R6, P.D)},
            Moves = new[] {new Move(new P(P.R7, P.C), new[] {new P(P.R6, P.D)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPieces = new[] {new P(P.R6, P.F)},
            Moves = new[] {new Move(new P(P.R7, P.G), new[] {new P(P.R6, P.F)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.G), CapturedPieces = new[] {new P(P.R6, P.F), new P(P.R6, P.H)},
            Moves = new[] {new Move(new P(P.R7, P.E), new[] {new P(P.R6, P.F)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.C), CapturedPieces = new[] {new P(P.R6, P.B), new P(P.R6, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R7, P.A), new[] {new P(P.R6, P.B)}, 1),
                new Move(new P(P.R7, P.E), new[] {new P(P.R6, P.D)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R5, P.E), CapturedPieces = new[] {new P(P.R6, P.D), new P(P.R6, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R7, P.C), new[] {new P(P.R6, P.D)}, 1),
                new Move(new P(P.R7, P.G), new[] {new P(P.R6, P.F)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.B), CapturedPieces = new[] {new P(P.R7, P.C), new P(P.R7, P.A)},
            Moves = new[] {new Move(new P(P.R8, P.D), new[] {new P(P.R7, P.C)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.D), CapturedPieces = new[] {new P(P.R7, P.C)},
            Moves = new[] {new Move(new P(P.R8, P.B), new[] {new P(P.R7, P.C)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.D), CapturedPieces = new[] {new P(P.R7, P.E)},
            Moves = new[] {new Move(new P(P.R8, P.F), new[] {new P(P.R7, P.E)}, 1)}
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.F), CapturedPieces = new[] {new P(P.R7, P.E)},
            Moves = new[] {new Move(new P(P.R8, P.D), new[] {new P(P.R7, P.E)}, 1)}
        };
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.F), CapturedPieces = new[] {new P(P.R7, P.G)},
            Moves = new[] {new Move(new P(P.R8, P.H), new[] {new P(P.R7, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.H), CapturedPieces = new[] {new P(P.R7, P.G)},
            Moves = new[] {new Move(new P(P.R8, P.F), new[] {new P(P.R7, P.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.C), CapturedPieces = new[] {new P(P.R7, P.B), new P(P.R7, P.D)},
            Moves = new[]
            {
                new Move(new P(P.R8, P.A), new[] {new P(P.R7, P.B)}, 1),
                new Move(new P(P.R8, P.E), new[] {new P(P.R7, P.D)}, 1)
            }
        };

        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R6, P.E), CapturedPieces = new[] {new P(P.R7, P.D), new P(P.R7, P.F)},
            Moves = new[]
            {
                new Move(new P(P.R8, P.C), new[] {new P(P.R7, P.D)}, 1),
                new Move(new P(P.R8, P.G), new[] {new P(P.R7, P.F)}, 1)
            }
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.A), CapturedPieces = new[] {new P(P.R8, P.B)},
            Moves = Enumerable.Empty<Move>()
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.C), CapturedPieces = new[] {new P(P.R8, P.B), new P(P.R8, P.D)},
            Moves = Enumerable.Empty<Move>()
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.E), CapturedPieces = new[] {new P(P.R8, P.D), new P(P.R8, P.F)},
            Moves = Enumerable.Empty<Move>()
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new P(P.R7, P.G), CapturedPieces = new[] {new P(P.R8, P.F), new P(P.R8, P.H)},
            Moves = Enumerable.Empty<Move>()
        };
    }
}