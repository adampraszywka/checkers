using System.Collections;
using P = Domain.Chessboard.Position;
using M = Domain.Chessboard.PieceMoves.PossibleMove;
using TC = DomainTests.Chessboard.PieceMoves.Classic.TestData.Dto.PieceCaptureTestCase;

namespace DomainTests.Chessboard.PieceMoves.Classic.TestData;

public class WhitePieceMultipleCapturesBlackPiecesTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TC {Source = P.A1, Captured = [P.B2, P.B4], Moves = [new M(P.A5, [P.B2, P.B4], 2)]};
        yield return new TC {Source = P.A1, Captured = [P.B2, P.D4], Moves = [new M(P.E5, [P.B2, P.D4], 2)]};
        yield return new TC {Source = P.A1, Captured = [P.B2, P.B4, P.D4], Moves = [new M(P.A5, [P.B2, P.B4], 2), new M(P.E5, [P.B2, P.D4], 2)]};
        
        yield return new TC {Source = P.A1, Captured = [P.B2, P.D4, P.F6], Moves = [new M(P.G7, [P.B2, P.D4, P.F6], 3)]};
        yield return new TC {Source = P.A1, Captured = [P.B2, P.D4, P.D6], Moves = [new M(P.C7, [P.B2, P.D4, P.D6], 3)]};
        yield return new TC
        {
            Source = P.A1, Captured = [P.B2, P.D4, P.D6, P.F6], 
            Moves = [new M(P.C7, [P.B2, P.D4, P.D6], 3), new M(P.G7, [P.B2, P.D4, P.F6], 3)]
        };

        // One of the following moves won't be available, implementation may need to be changed later 
        // yield return new TC
        // {
        //     Source = P.E3, Captured = [P.D4, P.F4, P.D6, P.F6],
        //     Moves = [new M(P.E7, [P.F4, P.F6], 2), new M(P.E7, [P.D4, P.D6], 2)]
        // };
        
        yield return new TC {Source = P.H4, Captured = [P.G5, P.E5, P.C3], Moves = [new M(P.B2, [P.G5, P.E5, P.C3], 3)]};
        yield return new TC {Source = P.H4, Captured = [P.G5, P.E5, P.C5], Moves = [new M(P.B6, [P.G5, P.E5, P.C5], 3)]};
        
        yield return new TC {Source = P.A1, Captured = [P.B2, P.D4, P.F4], Moves = [new M(P.G3, [P.B2, P.D4, P.F4], 3)]};
        yield return new TC {Source = P.A1, Captured = [P.B2, P.D4, P.F4, P.F2], Moves = [new M(P.E1, [P.B2, P.D4, P.F4, P.F2], 4)]};

        yield return new TC {Source = P.C1, Captured = [P.B2, P.B4, P.D6, P.F6, P.F4, P.F2], Moves = [new M(P.G1, [P.B2, P.B4, P.D6, P.F6, P.F4, P.F2], 6)]  };
        
        yield return new TC {Source = P.A1, Captured = [P.B2, P.D4], Blocking = [P.E5], Moves = [new M(P.C3, [P.B2], 1)]};
        yield return new TC {Source = P.C1, Captured = [P.D2, P.D4], Blocking = [P.C5], Moves = [new M(P.E3, [P.D2], 1)]};
        yield return new TC {Source = P.C3, Captured = [P.D4, P.F4], Blocking = [P.G3], Moves = [new M(P.E5, [P.D4], 1)]};
        yield return new TC {Source = P.G7, Captured = [P.F6, P.D4], Blocking = [P.C3], Moves = [new M(P.E5, [P.F6], 1)]};
    }
}