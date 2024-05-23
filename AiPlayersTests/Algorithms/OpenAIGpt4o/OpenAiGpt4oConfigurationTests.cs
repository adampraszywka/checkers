using AIPlayers.Algorithms.OpenAIGpt4o;

namespace AiPlayersTests.Algorithms.OpenAIGpt4o;

public class OpenAiGpt4oConfigurationTests
{
    [Test]
    public void DefaultValues()
    {
        var genericConfiguration = new Dictionary<string, string>();
        var configuration = new OpenAiGpt4oConfiguration(genericConfiguration);
        
        Assert.That(configuration.Temperature, Is.EqualTo(0.2f));
        Assert.That(configuration.Model, Is.EqualTo("gpt-4o"));
        Assert.That(configuration.RefereeEnabled, Is.False);
    }
    
    [Test]
    public void AllValuesSet()
    {
        var genericConfiguration = new Dictionary<string, string>
        {
           { "temperature", "0.5" },
           { "model", "gpt-4o" },
           { "refereeEnabled", "true" }
        };

        var configuration = new OpenAiGpt4oConfiguration(genericConfiguration);
        
        Assert.That(configuration.Temperature, Is.EqualTo(0.5f));
        Assert.That(configuration.Model, Is.EqualTo("gpt-4o"));
        Assert.That(configuration.RefereeEnabled, Is.True);
    }

    [Test]
    [TestCase("0.5", 0.5f)]
    // Not sure what will happen with this test case on US like culture
    [TestCase("0,5", 0.5f)]
    [TestCase("0", 0f)]
    [TestCase("1", 1f)]
    [TestCase(" 0.2", 0.2f)]
    [TestCase("0.2 ", 0.2f)]
    [TestCase(" 0.2 ", 0.2f)]
    public void TemperatureTests(string value, float expected)
    {
        var genericConfiguration = new Dictionary<string, string>
        {
            { "temperature", value }
        };
        
        var configuration = new OpenAiGpt4oConfiguration(genericConfiguration);
        
        Assert.That(configuration.Temperature, Is.EqualTo(expected));
    }
    
}