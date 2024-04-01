using System.Collections;
using Domain.PieceMoves;
using DomainTests.PieceMoves.Classic.TestData.Dto;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhitePieceCapturesBackwardBlackPiecesTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C3, CapturedPieces = new[] {P.B2, P.D2},
            Moves = new[]
            {
                new PossibleMove(P.A1, new[] {P.B2}, 1),
                new PossibleMove(P.E1, new[] {P.D2}, 1)
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E3, CapturedPieces = new[] {P.D2, P.F2},
            Moves = new[]
            {
                new PossibleMove(P.C1, new[] {P.D2}, 1),
                new PossibleMove(P.G1, new[] {P.F2}, 1)
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.G3, CapturedPieces = new[] {P.F2, P.H2},
            Moves = new[]
            {
                new PossibleMove(P.E1, new[] {P.F2}, 1),
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B4, CapturedPieces = new[] {P.A3, P.C3},
            Moves = new[] {new PossibleMove(P.D2, new[] {P.C3}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D4, CapturedPieces = new[] {P.C3, P.E3},
            Moves = new[]
            {
                new PossibleMove(P.B2, new[] {P.C3}, 1),
                new PossibleMove(P.F2, new[] {P.E3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F4, CapturedPieces = new[] {P.E3, P.G3},
            Moves = new[]
            {
                new PossibleMove(P.D2, new[] {P.E3}, 1),
                new PossibleMove(P.H2, new[] {P.G3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.H4, CapturedPieces = new[] {P.G3},
            Moves = new[] {new PossibleMove(P.F2, new[] {P.G3}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.A5, CapturedPieces = new[] {P.B4},
            Moves = new[] {new PossibleMove(P.C3, new[] {P.B4}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C5, CapturedPieces = new[] {P.B4, P.D4},
            Moves = new[]
            {
                new PossibleMove(P.A3, new[] {P.B4}, 1),
                new PossibleMove(P.E3, new[] {P.D4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E5, CapturedPieces = new[] {P.D4, P.F4},
            Moves = new[]
            {
                new PossibleMove(P.C3, new[] {P.D4}, 1),
                new PossibleMove(P.G3, new[] {P.F4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.G5, CapturedPieces = new[] {P.F4, P.H4},
            Moves = new[]
            {
                new PossibleMove(P.E3, new[] {P.F4}, 1),
            }
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.B6, CapturedPieces = new[] {P.A5, P.C5},
            Moves = new[] {new PossibleMove(P.D4, new[] {P.C5}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.D6, CapturedPieces = new[] {P.C5, P.E5},
            Moves = new[]
            {
                new PossibleMove(P.B4, new[] {P.C5}, 1),
                new PossibleMove(P.F4, new[] {P.E5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.F6, CapturedPieces = new[] {P.E5, P.G5},
            Moves = new[]
            {
                new PossibleMove(P.D4, new[] {P.E5}, 1),
                new PossibleMove(P.H4, new[] {P.G5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.H6, CapturedPieces = new[] {P.G5},
            Moves = new[] {new PossibleMove(P.F4, new[] {P.G5}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.A7, CapturedPieces = new[] {P.B6},
            Moves = new[] {new PossibleMove(P.C5, new[] {P.B6}, 1)}
        };
        
        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.C7, CapturedPieces = new[] {P.B6, P.D6},
            Moves = new[]
            {
                new PossibleMove(P.A5, new[] {P.B6}, 1),
                new PossibleMove(P.E5, new[] {P.D6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.E7, CapturedPieces = new[] {P.D6, P.F6},
            Moves = new[]
            {
                new PossibleMove(P.C5, new[] {P.D6}, 1),
                new PossibleMove(P.G5, new[] {P.F6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            SourcePiece = P.G7, CapturedPieces = new[] {P.F6, P.H6},
            Moves = new[]
            {
                new PossibleMove(P.E5, new[] {P.F6}, 1),
            }
        };
    }
}