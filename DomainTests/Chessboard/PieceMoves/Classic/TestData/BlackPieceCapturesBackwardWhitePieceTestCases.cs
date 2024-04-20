using System.Collections;
using Domain.Chessboard.PieceMoves;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class BlackPieceCapturesBackwardWhitePieceTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            Source = P.B6, Captured = new[] {P.A7, P.C7},
            Moves = new[] {new PossibleMove(P.D8, new[] {P.C7}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D6, Captured = new[] {P.C7, P.E7},
            Moves = new[]
            {
                new PossibleMove(P.B8, new[] {P.C7}, 1),
                new PossibleMove(P.F8, new[] {P.E7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.F6, Captured = new[] {P.E7, P.G7},
            Moves = new[]
            {
                new PossibleMove(P.D8, new[] {P.E7}, 1),
                new PossibleMove(P.H8, new[] {P.G7}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.H6, Captured = new[] {P.G7},
            Moves = new[]
            {
                new PossibleMove(P.F8, new[] {P.G7}, 1)
            }
        };


        yield return new PieceCaptureTestCase
        {
            Source = P.A5, Captured = new[] {P.B6},
            Moves = new[] {new PossibleMove(P.C7, new[] {P.B6}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.C5, Captured = new[] {P.B6, P.D6},
            Moves = new[]
            {
                new PossibleMove(P.A7, new[] {P.B6}, 1),
                new PossibleMove(P.E7, new[] {P.D6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E5, Captured = new[] {P.D6, P.F6},
            Moves = new[]
            {
                new PossibleMove(P.C7, new[] {P.D6}, 1),
                new PossibleMove(P.G7, new[] {P.F6}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.G5, Captured = new[] {P.F6, P.H6},
            Moves = new[]
            {
                new PossibleMove(P.E7, new[] {P.F6}, 1)
            }
        };


        yield return new PieceCaptureTestCase
        {
            Source = P.B4, Captured = new[] {P.A5, P.C5},
            Moves = new[] {new PossibleMove(P.D6, new[] {P.C5}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = new[] {P.C5, P.E5},
            Moves = new[]
            {
                new PossibleMove(P.B6, new[] {P.C5}, 1),
                new PossibleMove(P.F6, new[] {P.E5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.F4, Captured = new[] {P.E5, P.G5},
            Moves = new[]
            {
                new PossibleMove(P.D6, new[] {P.E5}, 1),
                new PossibleMove(P.H6, new[] {P.G5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.H4, Captured = new[] {P.G5},
            Moves = new[]
            {
                new PossibleMove(P.F6, new[] {P.G5}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.A3, Captured = new[] {P.B4},
            Moves = new[] {new PossibleMove(P.C5, new[] {P.B4}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.C3, Captured = new[] {P.B4, P.D4},
            Moves = new[]
            {
                new PossibleMove(P.A5, new[] {P.B4}, 1),
                new PossibleMove(P.E5, new[] {P.D4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.E3, Captured = new[] {P.D4, P.F4},
            Moves = new[]
            {
                new PossibleMove(P.C5, new[] {P.D4}, 1),
                new PossibleMove(P.G5, new[] {P.F4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.G3, Captured = new[] {P.F4, P.H4},
            Moves = new[]
            {
                new PossibleMove(P.E5, new[] {P.F4}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.B2, Captured = new[] {P.A3, P.C3},
            Moves = new[] {new PossibleMove(P.D4, new[] {P.C3}, 1)}
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.D2, Captured = new[] {P.C3, P.E3},
            Moves = new[]
            {
                new PossibleMove(P.B4, new[] {P.C3}, 1),
                new PossibleMove(P.F4, new[] {P.E3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.F2, Captured = new[] {P.E3, P.G3},
            Moves = new[]
            {
                new PossibleMove(P.D4, new[] {P.E3}, 1),
                new PossibleMove(P.H4, new[] {P.G3}, 1)
            }
        };

        yield return new PieceCaptureTestCase
        {
            Source = P.H2, Captured = new[] {P.G3},
            Moves = new[]
            {
                new PossibleMove(P.F4, new[] {P.G3}, 1)
            }
        };
    }
}