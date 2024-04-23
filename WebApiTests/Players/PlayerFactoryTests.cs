using Contracts.Players;
using WebApi.Players;
using WebApi.Players.Error;
using WebApi.Service.Errors;

namespace WebApiTests.Players;

public class PlayerFactoryTests
{
    [Test]
    [TestCase("someType")]
    public void NotSupported(string type)
    {
        var factory = new PlayerFactory();

        var result = factory.Create("ID", type);
        
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.HasError<InvalidAiPlayerType>());
    }

    [Test]
    public void CreateDummyAiPlayer()
    {
        var factory = new PlayerFactory();

        var playerResult = factory.Create("ID", AIDummyPlayer.TypeValue);
        var player = playerResult.Value;
        
        Assert.That(playerResult.IsSuccess);
        Assert.That(player, Is.TypeOf<AIDummyPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }

    [Test]
    public void CreateSignalrPlayer()
    {
        var factory = new PlayerFactory();

        var playerResult = factory.Create("ID", SignalRPlayer.TypeValue);
        var player = playerResult.Value;
        
        Assert.That(playerResult.IsSuccess);
        Assert.That(player, Is.TypeOf<SignalRPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }
    
    [Test]
    public void CreateHeaderPlayer()
    {
        var factory = new PlayerFactory();

        var playerResult = factory.Create("ID", HeaderPlayer.TypeValue);
        var player = playerResult.Value;

        Assert.That(playerResult.IsSuccess);
        Assert.That(player, Is.TypeOf<HeaderPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }
}