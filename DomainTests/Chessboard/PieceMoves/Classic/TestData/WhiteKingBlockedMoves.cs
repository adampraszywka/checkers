using System.Collections;
using DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto;
using P = Domain.Chessboard.Position;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class WhiteKingBlockedMoves : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = [], Blocking = [P.E5, P.F6, P.C5, P.B6, P.C3, P.B2, P.E3, P.F2], Moves = []
        };        
        yield return new PieceCaptureTestCase
        {
            Source = P.D4, Captured = [], Blocking = [P.F6, P.G7, P.B6, P.A7, P.B2, P.A1, P.F2, P.G1], 
            Moves = [
                new(P.E5, [P.E5], 0), new(P.C5, [P.C5], 0), 
                new(P.C3, [P.C3], 0), new(P.E3, [P.E3], 0)
            ]
        };
    }
}