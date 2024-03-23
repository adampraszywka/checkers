using Domain.Pieces;
using Domain.Pieces.Classic;
using Type = Domain.Pieces.Type;

namespace DomainTests.Pieces.Classic;

public class ClassicPieceFactoryTests
{
    [Test]
    public void WhiteManUpgrade()
    {
        var factory = new ClassicPieceFactory();
        var man = new Man("A1", Color.White);
        var king = factory.ReplacementFor(man);
        
        Assert.That(king.Id, Is.EqualTo("A1K"));
        Assert.That(king.Color, Is.EqualTo(Color.White));
        Assert.That(king.Type, Is.EqualTo(Type.King));
    }
    
    [Test]
    public void BlackManUpgrade()
    {
        var factory = new ClassicPieceFactory();
        var man = new Man("A1", Color.Black);
        var king = factory.ReplacementFor(man);
        
        Assert.That(king.Id, Is.EqualTo("A1K"));
        Assert.That(king.Color, Is.EqualTo(Color.Black));
        Assert.That(king.Type, Is.EqualTo(Type.King));
    }

    [Test]
    [TestCase(Color.White)]
    [TestCase(Color.Black)]
    public void KingUpgradeForbidden(Color color)
    {
        var factory = new ClassicPieceFactory();
        var king = new King("A1K", color);
        Assert.Throws<InvalidOperationException>(() => factory.ReplacementFor(king));
    }
}