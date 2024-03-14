using System.Collections;
using Domain;
using Domain.PieceMoves;
using P = Domain.Position;
namespace DomainTests.PieceMoves.Classic.TestData;

public class BlackManMovesForwardBlockingMoves : IEnumerable<BlockedMoveForwardTestCase>
{
    public IEnumerator<BlockedMoveForwardTestCase> GetEnumerator()
    {
        // Piece on B8, completely blocked by pieces on A7 and C7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.B), BlockingPieces = new List<Position> { new(P.R7, P.A), new(P.R7, P.C) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on D8, completely blocked by pieces on C7 and E7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.D), BlockingPieces = new List<Position> { new(P.R7, P.C), new(P.R7, P.E) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on F8, completely blocked by pieces on E7 and G7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.F), BlockingPieces = new List<Position> { new(P.R7, P.E), new(P.R7, P.G) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on H8, completely blocked by piece on G7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.H), BlockingPieces = new List<Position> { new(P.R7, P.G) },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on B8, blocked by piece on A7, move available to C7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.B), BlockingPieces = new List<Position> { new(P.R7, P.A) },
            Moves = new List<Move> {new (new P(P.R7, P.C), new List<Position> {new(P.R7, P.C)}, 0)}
        };

        // Piece on B8, blocked by piece on C7, move available to A7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.B), BlockingPieces = new List<Position> { new(P.R7, P.C) },
            Moves = new List<Move> {new (new P(P.R7, P.A), new List<Position> {new(P.R7, P.A)}, 0)}
        };

        // Piece on D8, blocked by piece on C7, move available to E7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.D), BlockingPieces = new List<Position> { new(P.R7, P.C) },
            Moves = new List<Move> {new (new P(P.R7, P.E), new List<Position> {new(P.R7, P.E)}, 0)}
        };

        // Piece on D8, blocked by piece on E7, move available to C7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.D), BlockingPieces = new List<Position> { new(P.R7, P.E) },
            Moves = new List<Move> {new (new P(P.R7, P.C), new List<Position> {new(P.R7, P.C)}, 0)}
        };

        // Piece on F8, blocked by piece on E7, move available to G7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.F), BlockingPieces = new List<Position> { new(P.R7, P.E) },
            Moves = new List<Move> {new (new P(P.R7, P.G), new List<Position> {new(P.R7, P.G)}, 0)}
        };

        // Piece on F8, blocked by piece on G7, move available to E7
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R8, P.F), BlockingPieces = new List<Position> { new(P.R7, P.G) },
            Moves = new List<Move> {new (new P(P.R7, P.E), new List<Position> {new(P.R7, P.E)}, 0)}
        };
        
        // Completely blocked scenarios
        // Piece on A7, moving to B6 (only one move available due to board limits)
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.A), BlockingPieces = new List<Position> { new(P.R6, P.B) }, // A7 can only move to B6
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on C7, completely blocked by pieces on B6 and D6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.C), BlockingPieces = new List<Position> { new(P.R6, P.B), new(P.R6, P.D) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on E7, completely blocked by pieces on D6 and F6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.E), BlockingPieces = new List<Position> { new(P.R6, P.D), new(P.R6, P.F) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on G7, completely blocked by pieces on F6 and H6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.G), BlockingPieces = new List<Position> { new(P.R6, P.F), new(P.R6, P.H) },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on C7, blocked by piece on B6, move available to D6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.C), BlockingPieces = new List<Position> { new(P.R6, P.B) },
            Moves = new List<Move> {new (new P(P.R6, P.D), new List<Position> {new(P.R6, P.D)}, 0)}
        };

        // Piece on C7, blocked by piece on D6, move available to B6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.C),
            BlockingPieces = new List<Position> { new(P.R6, P.D) },
            Moves = new List<Move> {new (new P(P.R6, P.B), new List<Position> {new(P.R6, P.B)}, 0)}
        };

        // Piece on E7, blocked by piece on D6, move available to F6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.E), BlockingPieces = new List<Position> { new(P.R6, P.D) },
            Moves = new List<Move> {new (new P(P.R6, P.F), new List<Position> {new(P.R6, P.F)}, 0)}
        };

        // Piece on E7, blocked by piece on F6, move available to D6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.E), BlockingPieces = new List<Position> { new(P.R6, P.F) },
            Moves = new List<Move> {new (new P(P.R6, P.D), new List<Position> {new(P.R6, P.D)}, 0)}
        };

        // Piece on G7, blocked by piece on F6, move available to H6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.G), BlockingPieces = new List<Position> { new(P.R6, P.F) },
            Moves = new List<Move> {new (new P(P.R6, P.H), new List<Position> {new(P.R6, P.H)}, 0)}
        };

        // Piece on G7, blocked by piece on H6, move available to F6
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R7, P.G), BlockingPieces = new List<Position> { new(P.R6, P.H) },
            Moves = new List<Move> {new (new P(P.R6, P.F), new List<Position> {new(P.R6, P.F)}, 0)}
        };

        
        // Completely blocked scenarios

        // Piece on B6, completely blocked by pieces on A5 and C5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.B), BlockingPieces = new List<Position> { new(P.R5, P.A), new(P.R5, P.C) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on D6, completely blocked by pieces on C5 and E5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.D), BlockingPieces = new List<Position> { new(P.R5, P.C), new(P.R5, P.E) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on F6, completely blocked by pieces on E5 and G5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.F), BlockingPieces = new List<Position> { new(P.R5, P.E), new(P.R5, P.G) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on H6, completely blocked by piece on G5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.H), BlockingPieces = new List<Position> { new(P.R5, P.G) }, // H6 can only move to G5
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios

        // Piece on B6, blocked by piece on A5, move available to C5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.B), BlockingPieces = new List<Position> { new(P.R5, P.A) },
            Moves = new List<Move> {new (new P(P.R5, P.C), new List<Position> {new(P.R5, P.C)}, 0)}
        };

        // Piece on B6, blocked by piece on C5, move available to A5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.B), BlockingPieces = new List<Position> { new(P.R5, P.C) },
            Moves = new List<Move> {new (new P(P.R5, P.A), new List<Position> {new(P.R5, P.A)}, 0)}
        };

        // Piece on D6, blocked by piece on C5, move available to E5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.D), BlockingPieces = new List<Position> { new(P.R5, P.C) },
            Moves = new List<Move> {new (new P(P.R5, P.E), new List<Position> {new(P.R5, P.E)}, 0)}
        };

        // Piece on D6, blocked by piece on E5, move available to C5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.D), BlockingPieces = new List<Position> { new(P.R5, P.E) },
            Moves = new List<Move> {new (new P(P.R5, P.C), new List<Position> {new(P.R5, P.C)}, 0)}
        };

        // Piece on F6, blocked by piece on E5, move available to G5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.F), BlockingPieces = new List<Position> { new(P.R5, P.E) },
            Moves = new List<Move> {new (new P(P.R5, P.G), new List<Position> {new(P.R5, P.G)}, 0)}
        };

        // Piece on F6, blocked by piece on G5, move available to E5
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R6, P.F), BlockingPieces = new List<Position> { new(P.R5, P.G) },
            Moves = new List<Move> {new (new P(P.R5, P.E), new List<Position> {new(P.R5, P.E)}, 0)}
        };
        
        // Completely blocked scenarios

        // Piece on A5, completely blocked by piece on B4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.A), BlockingPieces = new List<Position> { new(P.R4, P.B) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on C5, completely blocked by pieces on B4 and D4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.C), BlockingPieces = new List<Position> { new(P.R4, P.B), new(P.R4, P.D) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on E5, completely blocked by pieces on D4 and F4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.E), BlockingPieces = new List<Position> { new(P.R4, P.D), new(P.R4, P.F) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on G5, completely blocked by pieces on F4 and H4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.G), BlockingPieces = new List<Position> { new(P.R4, P.F), new(P.R4, P.H) },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios

        // Piece on A5, blocked by piece on B4, no other option due to edge
        // A5 has only one forward move, thus if blocked, no other moves available

        // Piece on C5, blocked by piece on B4, move available to D4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.C), BlockingPieces = new List<Position> { new(P.R4, P.B) },
            Moves = new List<Move> {new (new P(P.R4, P.D), new List<Position> {new(P.R4, P.D)}, 0)}
        };

        // Piece on C5, blocked by piece on D4, move available to B4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.C), BlockingPieces = new List<Position> { new(P.R4, P.D) },
            Moves = new List<Move> {new (new P(P.R4, P.B), new List<Position> {new(P.R4, P.B)}, 0)}
        };

        // Piece on E5, blocked by piece on D4, move available to F4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.E), BlockingPieces = new List<Position> { new(P.R4, P.D) },
            Moves = new List<Move> {new (new P(P.R4, P.F), new List<Position> {new(P.R4, P.F)}, 0)}
        };

        // Piece on E5, blocked by piece on F4, move available to D4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.E), BlockingPieces = new List<Position> { new(P.R4, P.F) },
            Moves = new List<Move> {new (new P(P.R4, P.D), new List<Position> {new(P.R4, P.D)}, 0)}
        };

        // Piece on G5, blocked by piece on F4, move available to H4
        // Note: Since G5 moving to H4 is an edge case, ensure your game rules accommodate for edge movements.
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.G), BlockingPieces = new List<Position> { new(P.R4, P.F) },
            Moves = new List<Move> {new (new P(P.R4, P.H), new List<Position> {new(P.R4, P.H)}, 0)}
        };

        // Piece on G5, blocked by piece on H4, move available to F4
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R5, P.G), BlockingPieces = new List<Position> { new(P.R4, P.H) },
            Moves = new List<Move> {new (new P(P.R4, P.F), new List<Position> {new(P.R4, P.F)}, 0)}
        };
        
        // Piece on B4, completely blocked by pieces on A3 and C3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.B), BlockingPieces = new List<Position> { new(P.R3, P.A), new(P.R3, P.C) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on D4, completely blocked by pieces on C3 and E3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.D), BlockingPieces = new List<Position> { new(P.R3, P.C), new(P.R3, P.E) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on F4, completely blocked by pieces on E3 and G3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.F), BlockingPieces = new List<Position> { new(P.R3, P.E), new(P.R3, P.G) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on H4, completely blocked by piece on G3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.H), BlockingPieces = new List<Position> { new(P.R3, P.G) },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on B4, blocked by piece on A3, move available to C3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.B), BlockingPieces = new List<Position> { new(P.R3, P.A) },
            Moves = new List<Move> {new (new P(P.R3, P.C), new List<Position> {new(P.R3, P.C)}, 0)}
        };

        // Piece on B4, blocked by piece on C3, move available to A3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.B), BlockingPieces = new List<Position> { new(P.R3, P.C) },
            Moves = new List<Move> {new (new P(P.R3, P.A), new List<Position> {new(P.R3, P.A)}, 0)}
        };

        // Piece on D4, blocked by piece on C3, move available to E3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.D), BlockingPieces = new List<Position> { new(P.R3, P.C) },
            Moves = new List<Move> {new (new P(P.R3, P.E), new List<Position> {new(P.R3, P.E)}, 0)}
        };

        // Piece on D4, blocked by piece on E3, move available to C3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.D), BlockingPieces = new List<Position> { new(P.R3, P.E) },
            Moves = new List<Move> {new (new P(P.R3, P.C), new List<Position> {new(P.R3, P.C)}, 0)}
        };

        // Piece on F4, blocked by piece on E3, move available to G3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.F), BlockingPieces = new List<Position> { new(P.R3, P.E) },
            Moves = new List<Move> {new (new P(P.R3, P.G), new List<Position> {new(P.R3, P.G)}, 0)}
        };

        // Piece on F4, blocked by piece on G3, move available to E3
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R4, P.F), BlockingPieces = new List<Position> { new(P.R3, P.G) },
            Moves = new List<Move> {new (new P(P.R3, P.E), new List<Position> {new(P.R3, P.E)}, 0)}
        };
        
        // Piece on A3, completely blocked by piece on B2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.A), BlockingPieces = new List<Position> { new(P.R2, P.B) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on C3, completely blocked by pieces on B2 and D2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.C), BlockingPieces = new List<Position> { new(P.R2, P.B), new(P.R2, P.D) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on E3, completely blocked by pieces on D2 and F2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.E), BlockingPieces = new List<Position> { new(P.R2, P.D), new(P.R2, P.F) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on G3, completely blocked by pieces on F2 and H2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.G), BlockingPieces = new List<Position> { new(P.R2, P.F), new(P.R2, P.H) },
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on C3, blocked by piece on B2, move available to D2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.C), BlockingPieces = new List<Position> { new(P.R2, P.B) },
            Moves = new List<Move>
            {
                new (new P(P.R2, P.D), new List<Position> {new(P.R2, P.D)}, 0)
            }
        };

        // Piece on C3, blocked by piece on D2, move available to B2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.C), BlockingPieces = new List<Position> { new(P.R2, P.D) },
            Moves = new List<Move> {new (new P(P.R2, P.B), new List<Position> {new(P.R2, P.B)}, 0)}
        };

        // Piece on E3, blocked by piece on D2, move available to F2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.E), BlockingPieces = new List<Position> { new(P.R2, P.D) },
            Moves = new List<Move> {new (new P(P.R2, P.F), new List<Position> {new(P.R2, P.F)}, 0)}
        };

        // Piece on E3, blocked by piece on F2, move available to D2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.E), BlockingPieces = new List<Position> { new(P.R2, P.F) },
            Moves = new List<Move> {new (new P(P.R2, P.D), new List<Position> {new(P.R2, P.D)}, 0)}
        };

        // Piece on G3, blocked by piece on F2, move available to H2
        // Note: The move to H2 is an edge scenario; ensure your game rules cover edge movements.
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.G), BlockingPieces = new List<Position> { new(P.R2, P.F) },
            Moves = new List<Move> {new (new P(P.R2, P.H), new List<Position> {new(P.R2, P.H)}, 0)}
        };

        // Piece on G3, blocked by piece on H2, move available to F2
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R3, P.G), BlockingPieces = new List<Position> { new(P.R2, P.H) },
            Moves = new List<Move> {new (new P(P.R2, P.F), new List<Position> {new(P.R2, P.F)}, 0)}
        };
        
        // Piece on B2, completely blocked by pieces on A1 and C1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.B), BlockingPieces = new List<Position> { new(P.R1, P.A), new(P.R1, P.C) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on D2, completely blocked by pieces on C1 and E1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.D), BlockingPieces = new List<Position> { new(P.R1, P.C), new(P.R1, P.E) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on F2, completely blocked by pieces on E1 and G1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.F), BlockingPieces = new List<Position> { new(P.R1, P.E), new(P.R1, P.G) },
            Moves = Enumerable.Empty<Move>()
        };

        // Piece on H2, completely blocked by piece on G1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.H), BlockingPieces = new List<Position> { new(P.R1, P.G) }, // H2 can only move to G1
            Moves = Enumerable.Empty<Move>()
        };

        // Side blocked scenarios
        // Piece on B2, blocked by piece on A1, move available to C1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.B), BlockingPieces = new List<Position> { new(P.R1, P.A) },
            Moves = new List<Move>
            {
                new (new P(P.R1, P.C), new List<Position> {new(P.R1, P.C)}, 0)
            }
        };

        // Piece on B2, blocked by piece on C1, move available to A1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.B), BlockingPieces = new List<Position> { new(P.R1, P.C) },
            Moves = new List<Move> {new (new P(P.R1, P.A), new List<Position> {new(P.R1, P.A)}, 0)}
        };

        // Piece on D2, blocked by piece on C1, move available to E1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.D), BlockingPieces = new List<Position> { new(P.R1, P.C) },
            Moves = new List<Move> {new (new P(P.R1, P.E), new List<Position> {new(P.R1, P.E)}, 0)}
        };

        // Piece on D2, blocked by piece on E1, move available to C1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.D), BlockingPieces = new List<Position> { new(P.R1, P.E) },
            Moves = new List<Move>{new (new P(P.R1, P.C), new List<Position> {new(P.R1, P.C)}, 0)}
        };

        // Piece on F2, blocked by piece on E1, move available to G1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.F), BlockingPieces = new List<Position> { new(P.R1, P.E) },
            Moves = new List<Move> {new (new P(P.R1, P.G), new List<Position> {new(P.R1, P.G)}, 0)}
        };

        // Piece on F2, blocked by piece on G1, move available to E1
        yield return new BlockedMoveForwardTestCase
        {
            SourcePiece = new P(P.R2, P.F), BlockingPieces = new List<Position> { new(P.R1, P.G) },
            Moves = new List<Move> {new (new P(P.R1, P.E), new List<Position> {new(P.R1, P.E)}, 0)}
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}