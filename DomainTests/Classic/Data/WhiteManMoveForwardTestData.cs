using System.Collections;
using Domain;

namespace DomainTests.Classic.Data;

public class WhiteManMoveForwardTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        // Moves to the left
        yield return new object[] {new Position(Position.R1, Position.A), new Position(Position.R2, Position.B)};
        yield return new object[] {new Position(Position.R1, Position.C), new Position(Position.R2, Position.B)};
        yield return new object[] {new Position(Position.R1, Position.E), new Position(Position.R2, Position.D)};
        yield return new object[] {new Position(Position.R1, Position.G), new Position(Position.R2, Position.F)};

        yield return new object[] {new Position(Position.R2, Position.B), new Position(Position.R3, Position.A)};
        yield return new object[] {new Position(Position.R2, Position.D), new Position(Position.R3, Position.C)};
        yield return new object[] {new Position(Position.R2, Position.F), new Position(Position.R3, Position.E)};
        yield return new object[] {new Position(Position.R2, Position.H), new Position(Position.R3, Position.G)};

        yield return new object[] {new Position(Position.R3, Position.A), new Position(Position.R4, Position.B)};
        yield return new object[] {new Position(Position.R3, Position.C), new Position(Position.R4, Position.B)};
        yield return new object[] {new Position(Position.R3, Position.E), new Position(Position.R4, Position.D)};
        yield return new object[] {new Position(Position.R3, Position.G), new Position(Position.R4, Position.F)};

        yield return new object[] {new Position(Position.R4, Position.B), new Position(Position.R5, Position.A)};
        yield return new object[] {new Position(Position.R4, Position.D), new Position(Position.R5, Position.C)};
        yield return new object[] {new Position(Position.R4, Position.F), new Position(Position.R5, Position.E)};
        yield return new object[] {new Position(Position.R4, Position.H), new Position(Position.R5, Position.G)};

        yield return new object[] {new Position(Position.R5, Position.A), new Position(Position.R6, Position.B)};
        yield return new object[] {new Position(Position.R5, Position.C), new Position(Position.R6, Position.B)};
        yield return new object[] {new Position(Position.R5, Position.E), new Position(Position.R6, Position.D)};
        yield return new object[] {new Position(Position.R5, Position.G), new Position(Position.R6, Position.F)};

        yield return new object[] {new Position(Position.R6, Position.B), new Position(Position.R7, Position.A)};
        yield return new object[] {new Position(Position.R6, Position.D), new Position(Position.R7, Position.C)};
        yield return new object[] {new Position(Position.R6, Position.F), new Position(Position.R7, Position.E)};
        yield return new object[] {new Position(Position.R6, Position.H), new Position(Position.R7, Position.G)};

        yield return new object[] {new Position(Position.R7, Position.A), new Position(Position.R8, Position.B)};
        yield return new object[] {new Position(Position.R7, Position.C), new Position(Position.R8, Position.B)};
        yield return new object[] {new Position(Position.R7, Position.E), new Position(Position.R8, Position.D)};
        yield return new object[] {new Position(Position.R7, Position.G), new Position(Position.R8, Position.F)};
        
        yield return new object[] { new Position(Position.R1, Position.C), new Position(Position.R2, Position.D) };
        yield return new object[] { new Position(Position.R1, Position.E), new Position(Position.R2, Position.F) };
        yield return new object[] { new Position(Position.R1, Position.G), new Position(Position.R2, Position.H) };

        yield return new object[] { new Position(Position.R2, Position.B), new Position(Position.R3, Position.A) };
        yield return new object[] { new Position(Position.R2, Position.D), new Position(Position.R3, Position.C) };
        yield return new object[] { new Position(Position.R2, Position.F), new Position(Position.R3, Position.E) };
        yield return new object[] { new Position(Position.R2, Position.H), new Position(Position.R3, Position.G) };

        yield return new object[] { new Position(Position.R3, Position.A), new Position(Position.R4, Position.B) };
        yield return new object[] { new Position(Position.R3, Position.C), new Position(Position.R4, Position.D) };
        yield return new object[] { new Position(Position.R3, Position.E), new Position(Position.R4, Position.F) };
        yield return new object[] { new Position(Position.R3, Position.G), new Position(Position.R4, Position.H) };

        yield return new object[] { new Position(Position.R4, Position.B), new Position(Position.R5, Position.A) };
        yield return new object[] { new Position(Position.R4, Position.D), new Position(Position.R5, Position.C) };
        yield return new object[] { new Position(Position.R4, Position.F), new Position(Position.R5, Position.E) };
        yield return new object[] { new Position(Position.R4, Position.H), new Position(Position.R5, Position.G) };

        yield return new object[] { new Position(Position.R5, Position.A), new Position(Position.R6, Position.B) };
        yield return new object[] { new Position(Position.R5, Position.C), new Position(Position.R6, Position.D) };
        yield return new object[] { new Position(Position.R5, Position.E), new Position(Position.R6, Position.F) };
        yield return new object[] { new Position(Position.R5, Position.G), new Position(Position.R6, Position.H) };

        yield return new object[] { new Position(Position.R6, Position.B), new Position(Position.R7, Position.A) };
        yield return new object[] { new Position(Position.R6, Position.D), new Position(Position.R7, Position.C) };
        yield return new object[] { new Position(Position.R6, Position.F), new Position(Position.R7, Position.E) };
        yield return new object[] { new Position(Position.R6, Position.H), new Position(Position.R7, Position.G) };

        yield return new object[] { new Position(Position.R7, Position.A), new Position(Position.R8, Position.B) };
        yield return new object[] { new Position(Position.R7, Position.C), new Position(Position.R8, Position.D) };
        yield return new object[] { new Position(Position.R7, Position.E), new Position(Position.R8, Position.F) };
        yield return new object[] { new Position(Position.R7, Position.G), new Position(Position.R8, Position.H) };
    }
}