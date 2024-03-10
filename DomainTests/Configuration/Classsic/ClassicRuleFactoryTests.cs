using Domain.Configurations.Classic;
using Domain.Pieces;

namespace DomainTests.Configuration.Classsic;

public class ClassicRuleFactoryTests
{
    [Test]
    [TestCase(Color.Black)]
    [TestCase(Color.White)]
    public void King(Color color)
    {
        var king = new King("1", color);
        var factory = new ClassicRuleFactory();
        
        Assert.That(factory.RulesFor(king), Is.TypeOf<ClassicKingRules>());
    }
    
    [Test]
    [TestCase(Color.Black)]
    [TestCase(Color.White)]
    public void Man(Color color)
    {
        var man = new Man("1", color);
        var factory = new ClassicRuleFactory();
        
        Assert.That(factory.RulesFor(man), Is.TypeOf<ClassicManRules>());
    }
}