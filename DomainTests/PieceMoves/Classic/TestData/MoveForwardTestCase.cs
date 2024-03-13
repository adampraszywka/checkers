using Domain;
using Domain.PieceMoves;

namespace DomainTests.PieceMoves.Classic.TestData;

public class MoveForwardTestCase
{
    public required Position Source { get; init; }
    public required IEnumerable<Move> Moves { get; init; }
}