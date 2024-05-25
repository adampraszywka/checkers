using AIPlayers.MessageHub;

namespace AiPlayersTests.MessageHub;

public class ScopedConfigurationTests
{
    [Test]
    public void NotConfigured()
    {
        var configuration = new ScopedConfiguration();
        
        Assert.Throws<InvalidOperationException>(() => _ = configuration.Entries);
    }

    [Test]
    public void Configured()
    {
        var entries = new Dictionary<string, string>
        {
            ["key"] = "value"
        };

        var configuration = new ScopedConfiguration();

        configuration.Configure(entries);

        Assert.That(configuration.Entries, Is.EqualTo(entries));
    }
    
    [Test]
    public void CannotConfigureTwice()
    {
        var configuration = new ScopedConfiguration();

        configuration.Configure(new Dictionary<string, string>());

        Assert.Throws<InvalidOperationException>(() => configuration.Configure(new Dictionary<string, string>()));
    }
}