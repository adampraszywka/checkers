using Domain;
using Domain.PieceMoves;

namespace DomainTests.PieceMoves.Classic.TestData.Dto;

public class MoveForwardTestCase
{
    public required Position Source { get; init; }
    public required IEnumerable<PossibleMove> Moves { get; init; }
}