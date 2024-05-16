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
        var result = PlayerFactory.Create("ID", type);
        
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.HasError<InvalidAiPlayerType>());
    }

    [Test]
    public void CreateDummyAiPlayer()
    {
        var playerResult = PlayerFactory.Create("ID", AIDummyPlayer.TypeValue);
        var player = playerResult.Value;
        
        Assert.That(playerResult.IsSuccess);
        Assert.That(player, Is.TypeOf<AIDummyPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }

    [Test]
    public void CreateSignalrPlayer()
    {
        var playerResult = PlayerFactory.Create("ID", SignalRPlayer.TypeValue);
        var player = playerResult.Value;
        
        Assert.That(playerResult.IsSuccess);
        Assert.That(player, Is.TypeOf<SignalRPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }
    
    [Test]
    public void CreateHeaderPlayer()
    {
        var playerResult = PlayerFactory.Create("ID", ApiPlayer.TypeValue);
        var player = playerResult.Value;

        Assert.That(playerResult.IsSuccess);
        Assert.That(player, Is.TypeOf<ApiPlayer>());
        Assert.That(player.Id, Is.EqualTo("ID"));
    }
}