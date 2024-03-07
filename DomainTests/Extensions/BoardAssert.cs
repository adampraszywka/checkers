using Extension;

namespace DomainTests.Extensions;

public static class BoardAssert
{
    public static void IsEquivalentTo<T>(T[,] expected, T[,] actual)
    {
        Assert.That(expected.Flatten(), Is.EquivalentTo(actual.Flatten()));
    }
}