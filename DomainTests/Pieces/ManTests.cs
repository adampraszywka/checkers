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
    }
}