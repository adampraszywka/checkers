using Domain;

namespace DomainTests;

public class TrueTests
{
    [Test]
    public void Test1()
    {
        var t = new True();
        Assert.That(t.IsTrue, Is.True);
    }
}