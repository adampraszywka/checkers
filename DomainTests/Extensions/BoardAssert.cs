using Extension;

namespace DomainTests.Extensions;

public static class BoardAssert
{
    public static void ReversedRowsEqualTo<T>(T[,] expected, T[,] actual)
    {
        Assert.That(expected.ReverseRows().Flatten(), Is.EqualTo(actual.Flatten()));
    }
    
    public static void EqualTo<T>(T[,] expected, T[,] actual) where T : class
    {
        Assert.That(expected.Flatten(), Is.EqualTo(actual.Flatten()));
    }
}