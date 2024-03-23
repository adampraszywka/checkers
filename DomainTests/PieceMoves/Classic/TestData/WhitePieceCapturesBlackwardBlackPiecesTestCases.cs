using System.Collections;
using Domain;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhitePieceCapturesBackwardBlackPiecesTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R3, Position.C), 
            CapturedPieces = new[] {new Position(Position.R2, Position.B), new Position(Position.R2, Position.D)},
            Moves = new[]
            {
                new Move(new Position(Position.R1, Position.A), new[] {new Position(Position.R2, Position.B)}, 1),
                new Move(new Position(Position.R1, Position.E), new[] {new Position(Position.R2, Position.D)}, 1)
            }
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R3, Position.E), 
            CapturedPieces = new[] {new Position(Position.R2, Position.D), new Position(Position.R2, Position.F)},
            Moves = new[]
            {
                new Move(new Position(Position.R1, Position.C), new[] {new Position(Position.R2, Position.D)}, 1),
                new Move(new Position(Position.R1, Position.G), new[] {new Position(Position.R2, Position.F)}, 1)
            }
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R3, Position.G), 
            CapturedPieces = new[] {new Position(Position.R2, Position.F), new Position(Position.R2, Position.H)},
            Moves = new[]
            {
                new Move(new Position(Position.R1, Position.E), new[] {new Position(Position.R2, Position.F)}, 1),
            }
        };
        
        // Capture from B4 through A3 to C2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R4, Position.B), 
            CapturedPieces = new[] {new Position(Position.R3, Position.A), new Position(Position.R3, Position.C)},
            Moves = new[] {new Move(new Position(Position.R2, Position.D), new[] {new Position(Position.R3, Position.C)}, 1)}
        };

        // Capture from D4 through C3 to A2 and E3 to G2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R4, Position.D), 
            CapturedPieces = new[] {new Position(Position.R3, Position.C), new Position(Position.R3, Position.E)},
            Moves = new[]
            {
                new Move(new Position(Position.R2, Position.B), new[] {new Position(Position.R3, Position.C)}, 1),
                new Move(new Position(Position.R2, Position.F), new[] {new Position(Position.R3, Position.E)}, 1)
            }
        };

        // Capture from F4 through E3 to C2 and G3 to H2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R4, Position.F), 
            CapturedPieces = new[] {new Position(Position.R3, Position.E), new Position(Position.R3, Position.G)},
            Moves = new[]
            {
                new Move(new Position(Position.R2, Position.D), new[] {new Position(Position.R3, Position.E)}, 1),
                new Move(new Position(Position.R2, Position.H), new[] {new Position(Position.R3, Position.G)}, 1)
            }
        };

        // Capture from H4 through G3 to F2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R4, Position.H), 
            CapturedPieces = new[] {new Position(Position.R3, Position.G)},
            Moves = new[] {new Move(new Position(Position.R2, Position.F), new[] {new Position(Position.R3, Position.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R5, Position.A), 
            CapturedPieces = new[] {new Position(Position.R4, Position.B)},
            Moves = new[] {new Move(new Position(Position.R3, Position.C), new[] {new Position(Position.R4, Position.B)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R5, Position.C), 
            CapturedPieces = new[] {new Position(Position.R4, Position.B), new Position(Position.R4, Position.D)},
            Moves = new[]
            {
                new Move(new Position(Position.R3, Position.A), new[] {new Position(Position.R4, Position.B)}, 1),
                new Move(new Position(Position.R3, Position.E), new[] {new Position(Position.R4, Position.D)}, 1)
            }
        };

        // Capture from E5 through D4 to B3 and F4 to H3
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R5, Position.E), 
            CapturedPieces = new[] {new Position(Position.R4, Position.D), new Position(Position.R4, Position.F)},
            Moves = new[]
            {
                new Move(new Position(Position.R3, Position.C), new[] {new Position(Position.R4, Position.D)}, 1),
                new Move(new Position(Position.R3, Position.G), new[] {new Position(Position.R4, Position.F)}, 1)
            }
        };

        // Capture from G5 through F4 to D3 and H4 to F3
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R5, Position.G), 
            CapturedPieces = new[] {new Position(Position.R4, Position.F), new Position(Position.R4, Position.H)},
            Moves = new[]
            {
                new Move(new Position(Position.R3, Position.E), new[] {new Position(Position.R4, Position.F)}, 1),
            }
        };
        
        // Capture from B4 through A3 to C2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R6, Position.B), 
            CapturedPieces = new[] {new Position(Position.R5, Position.A), new Position(Position.R5, Position.C)},
            Moves = new[] {new Move(new Position(Position.R4, Position.D), new[] {new Position(Position.R5, Position.C)}, 1)}
        };

        // Capture from D4 through C3 to A2 and E3 to G2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R6, Position.D), 
            CapturedPieces = new[] {new Position(Position.R5, Position.C), new Position(Position.R5, Position.E)},
            Moves = new[]
            {
                new Move(new Position(Position.R4, Position.B), new[] {new Position(Position.R5, Position.C)}, 1),
                new Move(new Position(Position.R4, Position.F), new[] {new Position(Position.R5, Position.E)}, 1)
            }
        };

        // Capture from F4 through E3 to C2 and G3 to H2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R6, Position.F), 
            CapturedPieces = new[] {new Position(Position.R5, Position.E), new Position(Position.R5, Position.G)},
            Moves = new[]
            {
                new Move(new Position(Position.R4, Position.D), new[] {new Position(Position.R5, Position.E)}, 1),
                new Move(new Position(Position.R4, Position.H), new[] {new Position(Position.R5, Position.G)}, 1)
            }
        };

        // Capture from H4 through G3 to F2
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R6, Position.H), 
            CapturedPieces = new[] {new Position(Position.R5, Position.G)},
            Moves = new[] {new Move(new Position(Position.R4, Position.F), new[] {new Position(Position.R5, Position.G)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R7, Position.A), 
            CapturedPieces = new[] {new Position(Position.R6, Position.B)},
            Moves = new[] {new Move(new Position(Position.R5, Position.C), new[] {new Position(Position.R6, Position.B)}, 1)}
        };
        
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R7, Position.C), 
            CapturedPieces = new[] {new Position(Position.R6, Position.B), new Position(Position.R6, Position.D)},
            Moves = new[]
            {
                new Move(new Position(Position.R5, Position.A), new[] {new Position(Position.R6, Position.B)}, 1),
                new Move(new Position(Position.R5, Position.E), new[] {new Position(Position.R6, Position.D)}, 1)
            }
        };

        // Capture from E5 through D4 to B3 and F4 to H3
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R7, Position.E), 
            CapturedPieces = new[] {new Position(Position.R6, Position.D), new Position(Position.R6, Position.F)},
            Moves = new[]
            {
                new Move(new Position(Position.R5, Position.C), new[] {new Position(Position.R6, Position.D)}, 1),
                new Move(new Position(Position.R5, Position.G), new[] {new Position(Position.R6, Position.F)}, 1)
            }
        };

        // Capture from G5 through F4 to D3 and H4 to F3
        yield return new SinglePieceCaptureTestCase
        {
            SourcePiece = new Position(Position.R7, Position.G), 
            CapturedPieces = new[] {new Position(Position.R6, Position.F), new Position(Position.R6, Position.H)},
            Moves = new[]
            {
                new Move(new Position(Position.R5, Position.E), new[] {new Position(Position.R6, Position.F)}, 1),
            }
        };
    }
}