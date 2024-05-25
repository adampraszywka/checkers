using AIPlayers.MessageHub;

namespace AiPlayersTests.MessageHub;

public class ScopedHubContextTests
{
    [Test]
    public void EmptyHubContext()
    {
        var context = new ScopedHubContext();
        
        Assert.Throws<InvalidOperationException>(() => _ = context.BoardId);
        Assert.Throws<InvalidOperationException>(() => _ = context.PlayerId);
    }

    [Test]
    public void ConfiguredHubContext()
    {
        var context = new ScopedHubContext();
        
        context.Configure("BOARD_ID", "PLAYER_ID");
        
        Assert.That(context.BoardId, Is.EqualTo("BOARD_ID"));
        Assert.That(context.PlayerId, Is.EqualTo("PLAYER_ID"));
    }
    
    [Test]
    public void CannotConfigureAlreadyConfiguredHub()
    {
        var context = new ScopedHubContext();
        
        context.Configure("BOARD_ID", "PLAYER_ID");
        
        Assert.Throws<InvalidOperationException>(() => context.Configure("BOARD_ID1", "PLAYER_ID1"));

    }
}