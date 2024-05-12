using System.Collections;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class KingCaptures : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = [P.E5, P.C5, P.C3, P.E3], Blocking = [],
            Moves =
            [
                new(P.F6, [P.E5, P.F6], 1), new(P.G7, [P.E5, P.F6, P.G7], 1), new(P.H8, [P.E5, P.F6, P.G7, P.H8], 1),
                new(P.B6, [P.C5, P.B6], 1), new(P.A7, [P.C5, P.B6, P.A7], 1),
                new(P.B2, [P.C3, P.B2], 1), new(P.A1, [P.C3, P.B2, P.A1], 1),
                new(P.F2, [P.E3, P.F2], 1), new(P.G1, [P.E3, P.F2, P.G1], 1)
            ]
        };
    }
}