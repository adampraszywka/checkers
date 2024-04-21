using Contracts.Players;
using WebApi.Players;

namespace WebApiTests.Players;

public class PlayerFactoryTests
{
    [Test]
    [TestCase("someType")]
    public void NotSupported(string type)
    {
        var factory = new PlayerFactory();

        Assert.Throws<ArgumentException>(() => _ = factory.Create("ID", type));
    }

    [Test]
    public void CreateDummyAiPlayer()
    {
        var factory = new PlayerFactory();

        var player = factory.Create("ID", AIDummyPlayer.TypeValue);
        
        Assert.That(player, Is.TypeOf<AIDummyPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }

    [Test]
    public void CreateSignalrPlayer()
    {
        var factory = new PlayerFactory();

        var player = factory.Create("ID", SignalRPlayer.TypeValue);
        
        Assert.That(player, Is.TypeOf<SignalRPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }
    
    [Test]
    public void CreateHeaderPlayer()
    {
        var factory = new PlayerFactory();

        var player = factory.Create("ID", HeaderPlayer.TypeValue);
        
        Assert.That(player, Is.TypeOf<HeaderPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }
}