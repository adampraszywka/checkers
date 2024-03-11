using Domain;
using Domain.Configurations.Classic;
using Domain.Pieces;

namespace DomainTests.Pieces;

public class ManTests
{
    [Test]
    [TestCase(Color.Black)]
    [TestCase(Color.White)]
    public void NewMan(Color color)
    {
        var man = new Man("ID", color);
        
        Assert.That(man.Id, Is.EqualTo("ID"));
        Assert.That(man.Color, Is.EqualTo(color));
        Assert.Null(man.Square);
    }
    
    [Test]
    public void Attach()
    {
        var man = new Man("ID", Color.White);
        var square = Square.FromCoordinates(0, 0);
        
        man.Attach(square);
        
        Assert.That(man.Square, Is.SameAs(square));
    }

    [Test]
    public void RemoveSquareConnection()
    {
        var man = new Man("ID", Color.White);
        var square = Square.FromCoordinates(0, 0);
        
        man.Attach(square);
        man.Remove();
        
        Assert.Null(man.Square);
    }

}