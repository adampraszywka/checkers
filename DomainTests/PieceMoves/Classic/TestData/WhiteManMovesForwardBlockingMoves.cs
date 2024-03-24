using System.Collections;
using Domain;
using Domain.PieceMoves;
using P = Domain.Position;

namespace DomainTests.PieceMoves.Classic.TestData;

public class WhiteManMovesForwardBlockingMoves : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
         // Piece on A1, can move to B2 (no blocker scenario for A1 as it's the edge)
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.A1, BlockingPieces = new List<Position>(), // No blocking pieces for A1 on the first move
            Moves = new List<Move> {new (P.B2, new List<Position> {P.B2}, 0)}
        };

        // Piece on C1, blocked by a piece on B2, but has an available move to D2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C1, BlockingPieces = new List<Position> {P.B2},
            Moves = new List<Move> {new (P.D2, new List<Position> {P.D2}, 0)}
        };

        // Piece on C1, blocked by a piece on D2, but has an available move to B2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C1, BlockingPieces = new List<Position> {P.D2},
            Moves = new List<Move> {new (P.B2, new List<Position> {P.B2}, 0)}
        };

        // Piece on E1, can be blocked on one side and have another side open (two scenarios)
        // Blocked by D2, move to F2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E1, BlockingPieces = new List<Position> {P.D2},
            Moves = new List<Move> {new (P.F2, new List<Position> {P.F2}, 0)}
        };
        // Blocked by F2, move to D2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E1, BlockingPieces = new List<Position> {P.F2},
            Moves = new List<Move> {new (P.D2, new List<Position> {P.D2}, 0)}
        };

        // Piece on G1, can be blocked on one side and have another side open (two scenarios)
        // Blocked by F2, move to H2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G1, BlockingPieces = new List<Position> {P.F2},
            Moves = new List<Move> {new (P.H2, new List<Position> {P.H2}, 0)}
        };
        // Blocked by H2, move to F2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G1, BlockingPieces = new List<Position> {P.H2},
            Moves = new List<Move> {new (P.F2, new List<Position> {P.F2}, 0)}
        };
        
        // Piece on C1, completely blocked by pieces on B2 and D2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C1, BlockingPieces = new List<Position> { P.B2, P.D2 }, 
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on E1, completely blocked by pieces on D2 and F2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E1, BlockingPieces = new List<Position> { P.D2, P.F2 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on G1, completely blocked by pieces on F2 and H2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G1, BlockingPieces = new List<Position> { P.F2, P.H2 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on B2, blocked by piece on A3, move available to C3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B2, BlockingPieces = new List<Position> { P.A3 },
            Moves = new List<Move> {new (P.C3, new List<Position> {P.C3}, 0)}
        };

        // Piece on B2, blocked by piece on C3, move available to A3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B2, BlockingPieces = new List<Position> { P.C3 },
            Moves = new List<Move> {new (P.A3, new List<Position> {P.A3}, 0)}
        };

        // Piece on D2, blocked by piece on C3, move available to E3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D2, BlockingPieces = new List<Position> { P.C3 },
            Moves = new List<Move> {new (P.E3, new List<Position> {P.E3}, 0)}
        };

        // Piece on D2, blocked by piece on E3, move available to C3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D2, BlockingPieces = new List<Position> { P.E3 },
            Moves = new List<Move> {new (P.C3, new List<Position> {P.C3}, 0)}
        };

        // Piece on F2, blocked by piece on E3, move available to G3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F2, BlockingPieces = new List<Position> { P.E3 },
            Moves = new List<Move> {new (P.G3, new List<Position> {P.G3}, 0)}
        };

        // Piece on F2, blocked by piece on G3, move available to E3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F2, BlockingPieces = new List<Position> { P.G3 },
            Moves = new List<Move> {new (P.E3, new List<Position> {P.E3}, 0)}
        };
        
        // Piece on B2, completely blocked by pieces on A3 and C3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B2, BlockingPieces = new List<Position> { P.A3, P.C3 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on D2, completely blocked by pieces on C3 and E3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D2, BlockingPieces = new List<Position> { P.C3, P.E3 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on F2, completely blocked by pieces on E3 and G3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F2, BlockingPieces = new List<Position> { P.E3, P.G3 },
            Moves = Enumerable.Empty<Move>()
        };
        
        // Piece on C3, blocked by piece on B4, move available to D4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C3, BlockingPieces = new List<Position> { P.B4 },
            Moves = new List<Move> {new (P.D4, new List<Position> {P.D4}, 0)}
        };

        // Piece on C3, blocked by piece on D4, move available to B4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C3, BlockingPieces = new List<Position> { P.D4 },
            Moves = new List<Move> {new (P.B4, new List<Position> {P.B4}, 0)}
        };

        // Piece on E3, blocked by piece on D4, move available to F4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E3, BlockingPieces = new List<Position> { P.D4 },
            Moves = new List<Move> {new (P.F4, new List<Position> {P.F4}, 0)}
        };

        // Piece on E3, blocked by piece on F4, move available to D4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E3, BlockingPieces = new List<Position> { P.F4 },
            Moves = new List<Move> {new (P.D4, new List<Position> {P.D4}, 0)}
        };

        // Piece on G3, blocked by piece on F4, move available to H4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G3, BlockingPieces = new List<Position> { P.F4 },
            Moves = new List<Move> {new (P.H4, new List<Position> {P.H4}, 0)}
        };

        // Piece on G3, blocked by piece on H4, move available to F4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G3, BlockingPieces = new List<Position> { P.H4 },
            Moves = new List<Move> {new (P.F4, new List<Position> {P.F4}, 0)}
        };
        
        // Piece on A3, completely blocked by pieces on B4 and doesn't have D4 as an option due to board configuration
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.A3, BlockingPieces = new List<Position> { P.B4 }, // Only one blocker since it's an edge
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on C3, completely blocked by pieces on B4 and D4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C3, BlockingPieces = new List<Position> { P.B4, P.D4 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on E3, completely blocked by pieces on D4 and F4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E3, BlockingPieces = new List<Position> { P.D4, P.F4 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on G3, completely blocked by pieces on F4 and H4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G3, BlockingPieces = new List<Position> { P.F4, P.H4 },
            Moves = Enumerable.Empty<Move>()
        };
        
         // Piece on B4, completely blocked by pieces on A5 and C5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B4, BlockingPieces = new List<Position> { P.A5, P.C5 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on D4, completely blocked by pieces on C5 and E5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D4, BlockingPieces = new List<Position> { P.C5, P.E5 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on F4, completely blocked by pieces on E5 and G5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F4, BlockingPieces = new List<Position> { P.E5, P.G5 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on H4, completely blocked by pieces on G5
        // Note: H4 can only move to G5 due to being at the edge
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.H4, BlockingPieces = new List<Position> { P.G5 },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on B4, blocked by piece on A5, move available to C5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B4, BlockingPieces = new List<Position> { P.A5 },
            Moves = new List<Move> {new (P.C5, new List<Position> {P.C5}, 0)}
        };

        // Piece on B4, blocked by piece on C5, move available to A5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B4, BlockingPieces = new List<Position> { P.C5 },
            Moves = new List<Move> {new (P.A5, new List<Position> {P.A5}, 0)}
        };

        // Piece on D4, blocked by piece on C5, move available to E5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D4, BlockingPieces = new List<Position> { P.C5 },
            Moves = new List<Move> {new (P.E5, new List<Position> {P.E5}, 0)}
        };

        // Piece on D4, blocked by piece on E5, move available to C5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D4, BlockingPieces = new List<Position> { P.E5 },
            Moves = new List<Move> {new (P.C5, new List<Position> {P.C5}, 0)}
        };

        // Piece on F4, blocked by piece on E5, move available to G5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F4, BlockingPieces = new List<Position> { P.E5 },
            Moves = new List<Move> {new (P.G5, new List<Position> {P.G5}, 0)}
        };

        // Piece on F4, blocked by piece on G5, move available to E5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F4, BlockingPieces = new List<Position> { P.G5 },
            Moves = new List<Move> {new (P.E5, new List<Position> {P.E5}, 0)}
        };
        
        // Piece on A5, completely blocked by pieces on B6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.A5, BlockingPieces = new List<Position> { P.B6 }, // A5 can only move to B6
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on C5, completely blocked by pieces on B6 and D6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C5, BlockingPieces = new List<Position> { P.B6, P.D6 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on E5, completely blocked by pieces on D6 and F6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E5, BlockingPieces = new List<Position> { P.D6, P.F6 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on G5, completely blocked by pieces on F6 and H6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G5, BlockingPieces = new List<Position> { P.F6, P.H6 },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on A5, partially blocked scenarios are not applicable since A5 can only move to B6
        // Piece on C5, blocked by piece on B6, move available to D6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C5, BlockingPieces = new List<Position> { P.B6 },
            Moves = new List<Move> {new (P.D6, new List<Position> {P.D6}, 0)}
        };

        // Piece on C5, blocked by piece on D6, move available to B6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C5, BlockingPieces = new List<Position> { P.D6 },
            Moves = new List<Move> {new (P.B6, new List<Position> {P.B6}, 0)}
        };

        // Piece on E5, blocked by piece on D6, move available to F6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E5, BlockingPieces = new List<Position> { P.D6 },
            Moves = new List<Move> {new (P.F6, new List<Position> {P.F6}, 0)}
        };

        // Piece on E5, blocked by piece on F6, move available to D6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E5, BlockingPieces = new List<Position> { P.F6 },
            Moves = new List<Move> {new (P.D6, new List<Position> {P.D6}, 0)}
        };

        // Piece on G5, blocked by piece on F6, move available to H6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G5, BlockingPieces = new List<Position> { P.F6 },
            Moves = new List<Move> {new (P.H6, new List<Position> {P.H6}, 0)}
        };

        // Piece on G5, blocked by piece on H6, move available to F6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G5, BlockingPieces = new List<Position> { P.H6 },
            Moves = new List<Move> {new (P.F6, new List<Position> {P.F6}, 0)}
        };
        
        // Piece on B6, completely blocked by pieces on A7 and C7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B6, BlockingPieces = new List<Position> { P.A7, P.C7 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on D6, completely blocked by pieces on C7 and E7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D6, BlockingPieces = new List<Position> { P.C7, P.E7 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on F6, completely blocked by pieces on E7 and G7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F6, BlockingPieces = new List<Position> { P.E7, P.G7 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on H6, completely blocked by piece on G7 (H6 has no H7 move)
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.H6, BlockingPieces = new List<Position> { P.G7 },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios

        // Piece on B6, blocked by piece on A7, move available to C7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B6, BlockingPieces = new List<Position> { P.A7 },
            Moves = new List<Move> {new (P.C7, new List<Position> {P.C7}, 0)}
        };

        // Piece on B6, blocked by piece on C7, move available to A7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.B6, BlockingPieces = new List<Position> { P.C7 },
            Moves = new List<Move> {new (P.A7, new List<Position> {P.A7}, 0)}
        };

        // Piece on D6, blocked by piece on C7, move available to E7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D6, BlockingPieces = new List<Position> { P.C7 },
            Moves = new List<Move> {new (P.E7, new List<Position> {P.E7}, 0)}
        };

        // Piece on D6, blocked by piece on E7, move available to C7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.D6, BlockingPieces = new List<Position> { P.E7 },
            Moves = new List<Move> {new (P.C7, new List<Position> {P.C7}, 0)}
        };

        // Piece on F6, blocked by piece on E7, move available to G7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F6, BlockingPieces = new List<Position> { P.E7 },
            Moves = new List<Move> {new (P.G7, new List<Position> {P.G7}, 0)}
        };

        // Piece on F6, blocked by piece on G7, move available to E7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.F6, BlockingPieces = new List<Position> { P.G7 },
            Moves = new List<Move> {new(P.E7, new List<Position> {P.E7}, 0)}
        };
        
        // Piece on A7, moving to B8 (only one move available due to board limits)
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.A7, BlockingPieces = new List<Position> { P.B8 }, // A7 can only move to B8
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on C7, completely blocked by pieces on B8 and D8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C7, BlockingPieces = new List<Position> { P.B8, P.D8 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on E7, completely blocked by pieces on D8 and F8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E7, BlockingPieces = new List<Position> { P.D8, P.F8 },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on G7, completely blocked by pieces on F8 and H8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G7, BlockingPieces = new List<Position> { P.F8, P.H8 },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on A7, blocked scenarios are not applicable since A7 can only move to B8
        // Piece on C7, blocked by piece on B8, move available to D8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C7, BlockingPieces = new List<Position> { P.B8 },
            Moves = new List<Move> {new (P.D8, new List<Position> {P.D8}, 0)}
        };

        // Piece on C7, blocked by piece on D8, move available to B8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.C7, BlockingPieces = new List<Position> { P.D8 },
            Moves = new List<Move> {new (P.B8, new List<Position> {P.B8}, 0)}
        };

        // Piece on E7, blocked by piece on D8, move available to F8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E7, BlockingPieces = new List<Position> { P.D8 }, 
            Moves = new List<Move> {new (P.F8, new List<Position> {P.F8}, 0)}
        };

        // Piece on E7, blocked by piece on F8, move available to D8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.E7, BlockingPieces = new List<Position> { P.F8 },
            Moves = new List<Move> {new (P.D8, new List<Position> {P.D8}, 0)}
        };

        // Piece on G7, blocked by piece on F8, move available to H8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G7, BlockingPieces = new List<Position> { P.F8 },
            Moves = new List<Move> {new (P.H8, new List<Position> {P.H8}, 0)}
        };

        // Piece on G7, blocked by piece on H8, move available to F8
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = P.G7, BlockingPieces = new List<Position> { P.H8 },
            Moves = new List<Move> {new (P.F8, new List<Position> {P.F8}, 0)}
        };
    }
}