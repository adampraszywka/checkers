using Domain.Configurations;

namespace DomainTests;

public class BoardSizeTests
{
    [Test]
    [TestCase(8, 8)]
    [TestCase(8, 4)]
    [TestCase(4, 8)]
    public void Valid(int rows, int columns)
    {
        var size = new BoardSize(rows, columns);
        
        Assert.That(size.Rows, Is.EqualTo(rows));;
        Assert.That(size.Columns, Is.EqualTo(columns));;
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(8, 0)]
    [TestCase(0, 8)]
    [TestCase(-1, -1)]
    public void Invalid(int rows, int columns)
    {
        Assert.Throws<ArgumentException>(() => _ = new BoardSize(rows, columns));
    }
}