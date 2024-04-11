using System.Text.Json;
using Domain.Chessboard.PieceMoves;

namespace DomainTests.Extensions;

public static class MoveAssert
{
    public static void AreEqual(IEnumerable<PossibleMove> expected, IEnumerable<PossibleMove> actual)
    {
        var orderedExpected = expected
            .OrderBy(x => x.To.Row)
            .ThenBy(x => x.To.Column);

        var orderedActual = actual
            .OrderBy(x => x.To.Row)
            .ThenBy(x => x.To.Column);


        var expectedString = JsonSerializer.Serialize(orderedExpected);
        var actualString = JsonSerializer.Serialize(orderedActual);

        Assert.That(actualString, Is.EqualTo(expectedString));
    }
}