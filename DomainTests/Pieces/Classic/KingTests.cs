using Domain.Pieces;
using Domain.Pieces.Classic;

namespace DomainTests.Pieces.Classic;

public class KingTests
{
    [Test]
    [TestCase(Color.Black)]
    [TestCase(Color.White)]
    public void NewKing(Color color)
    {
        var king = new King("ID", color);
        
        Assert.That(king.Id, Is.EqualTo("ID"));
        Assert.That(king.Color, Is.EqualTo(color));
    }
}