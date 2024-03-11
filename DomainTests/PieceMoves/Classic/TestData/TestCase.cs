using Domain;
using Domain.PieceMoves;

namespace DomainTests.PieceMoves.Classic.TestData;

public class TestCase
{
    public required Position Source { get; init; }
    public required IEnumerable<Move> Moves { get; init; }
}