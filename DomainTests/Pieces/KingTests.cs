using Domain;
using Domain.Pieces;

namespace DomainTests.Pieces;

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
        Assert.Null(king.Square);
    }
    
    [Test]
    public void Attach()
    {
        var king = new King("ID", Color.White);
        var square = Square.FromCoordinates(0, 0);
        
        king.Attach(square);
        
        Assert.That(king.Square, Is.SameAs(square));
    }

    [Test]
    public void RemoveSquareConnection()
    {
        var king = new King("ID", Color.White);
        var square = Square.FromCoordinates(0, 0);
        
        king.Attach(square);
        king.Remove();
        
        Assert.Null(king.Square);
    }
}