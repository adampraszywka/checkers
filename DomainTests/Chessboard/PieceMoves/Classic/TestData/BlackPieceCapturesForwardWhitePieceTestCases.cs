using System.Collections;
using Domain.Chessboard.PieceMoves;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class BlackPieceCapturesForwardWhitePieceTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            Source = P.B8, Captured = new[] {P.C7, P.A7},
            Moves = new[] {new PossibleMove(P.D6, new[] {P.C7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D8, Captured = new[] {P.C7},
            Moves = new[] {new PossibleMove(P.B6, new[] {P.C7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D8, Captured = new[] {P.E7},
            Moves = new[] {new PossibleMove(P.F6, new[] {P.E7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.F8, Captured = new[] {P.E7},
            Moves = new[] {new PossibleMove(P.D6, new[] {P.E7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.F8, Captured = new[] {P.G7},
            Moves = new[] {new PossibleMove(P.H6, new[] {P.G7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.H8, Captured = new[] {P.G7},
            Moves = new[] {new PossibleMove(P.F6, new[] {P.G7}, 1)}
        };


        yield return new PieceCaptureTestCase
        {
            Source = P.D8, Captured = new[] {P.C7, P.E7},
            Moves = new[]
            {
                new PossibleMove(P.B6, new[] {P.C7}, 1),
                new PossibleMove(P.F6, new[] {P.E7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.F8, Captured = new[] {P.E7, P.G7},
            Moves = new[]
            {
                new PossibleMove(P.D6, new[] {P.E7}, 1),
                new PossibleMove(P.H6, new[] {P.G7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.A7, Captured = new[] {P.B6},
            Moves = new[] {new PossibleMove(P.C5, new[] {P.B6}, 1)}
        };


        yield return new PieceCaptureTestCase
        {
            Source = P.C7, Captured = new[] {P.B6},
            Moves = new[] {new PossibleMove(P.A5, new[] {P.B6}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.C7, Captured = new[] {P.D6},
            Moves = new[] {new PossibleMove(P.E5, new[] {P.D6}, 1)}
        };

        // Black piece on E7, capturing towards D6 or F6
        yield return new PieceCaptureTestCase
        {
            Source = P.E7, Captured = new[] {P.D6},
            Moves = new[] {new PossibleMove(P.C5, new[] {P.D6}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E7, Captured = new[] {P.F6},
            Moves = new[] {new PossibleMove(P.G5, new[] {P.F6}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            Source = P.C7, Captured = new[] {P.B6, P.D6},
            Moves = new[]
            {
                new PossibleMove(P.A5, new[] {P.B6}, 1),
                new PossibleMove(P.E5, new[] {P.D6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E7, Captured = new[] {P.D6, P.F6},
            Moves = new[]
            {
                new PossibleMove(P.C5, new[] {P.D6}, 1),
                new PossibleMove(P.G5, new[] {P.F6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.B6, Captured = new[] {P.C5},
            Moves = new[] {new PossibleMove(P.D4, new[] {P.C5}, 1)}
        };

        // Black piece on D6, capturing towards C5 or E5
        yield return new PieceCaptureTestCase
        {
            Source = P.D6, Captured = new[] {P.C5},
            Moves = new[] {new PossibleMove(P.B4, new[] {P.C5}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D6, Captured = new[] {P.E5},
            Moves = new[] {new PossibleMove(P.F4, new[] {P.E5}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            Source = P.B6, Captured = new[] {P.A5, P.C5},
            Moves = new[]
            {
                new PossibleMove(P.D4, new[] {P.C5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D6, Captured = new[] {P.C5, P.E5},
            Moves = new[]
            {
                new PossibleMove(P.B4, new[] {P.C5}, 1),
                new PossibleMove(P.F4, new[] {P.E5}, 1)
            }
        };
        yield return new PieceCaptureTestCase
        {
            Source = P.C5, Captured = new[] {P.B4},
            Moves = new[] {new PossibleMove(P.A3, new[] {P.B4}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.C5, Captured = new[] {P.D4},
            Moves = new[] {new PossibleMove(P.E3, new[] {P.D4}, 1)}
        };

        // Black piece on E5, capturing towards D4 or F4
        yield return new PieceCaptureTestCase
        {
            Source = P.E5, Captured = new[] {P.D4},
            Moves = new[] {new PossibleMove(P.C3, new[] {P.D4}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E5, Captured = new[] {P.F4},
            Moves = new[] {new PossibleMove(P.G3, new[] {P.F4}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            Source = P.C5, Captured = new[] {P.B4, P.D4},
            Moves = new[]
            {
                new PossibleMove(P.A3, new[] {P.B4}, 1),
                new PossibleMove(P.E3, new[] {P.D4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E5, Captured = new[] {P.D4, P.F4},
            Moves = new[]
            {
                new PossibleMove(P.C3, new[] {P.D4}, 1),
                new PossibleMove(P.G3, new[] {P.F4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.B4, Captured = new[] {P.C3, P.A3},
            Moves = new[] {new PossibleMove(P.D2, new[] {P.C3}, 1)}
        };

        // Black piece on D4, capturing towards C3 or E3
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = new[] {P.C3},
            Moves = new[] {new PossibleMove(P.B2, new[] {P.C3}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = new[] {P.E3},
            Moves = new[] {new PossibleMove(P.F2, new[] {P.E3}, 1)}
        };

        // Cases with multiple capturing options

        yield return new PieceCaptureTestCase
        {
            Source = P.B4, Captured = new[] {P.A3, P.C3},
            Moves = new[]
            {
                new PossibleMove(P.D2, new[] {P.C3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = new[] {P.C3, P.E3},
            Moves = new[]
            {
                new PossibleMove(P.B2, new[] {P.C3}, 1),
                new PossibleMove(P.F2, new[] {P.E3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.C3, Captured = new[] {P.B2},
            Moves = new[] {new PossibleMove(P.A1, new[] {P.B2}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.C3, Captured = new[] {P.D2},
            Moves = new[] {new PossibleMove(P.E1, new[] {P.D2}, 1)}
        };

        // Black piece on E3, capturing towards D2 or F2
        yield return new PieceCaptureTestCase
        {
            Source = P.E3, Captured = new[] {P.D2},
            Moves = new[] {new PossibleMove(P.C1, new[] {P.D2}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E3, Captured = new[] {P.F2},
            Moves = new[] {new PossibleMove(P.G1, new[] {P.F2}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.C3, Captured = new[] {P.B2, P.D2},
            Moves = new[]
            {
                new PossibleMove(P.A1, new[] {P.B2}, 1),
                new PossibleMove(P.E1, new[] {P.D2}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E3, Captured = new[] {P.D2, P.F2},
            Moves = new[]
            {
                new PossibleMove(P.C1, new[] {P.D2}, 1),
                new PossibleMove(P.G1, new[] {P.F2}, 1)
            }
        };
    }
}