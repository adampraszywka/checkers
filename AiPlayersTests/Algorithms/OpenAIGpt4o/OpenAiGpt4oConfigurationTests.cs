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
    [TestCase("gpt-4o", "gpt-4o")]
    [TestCase("gpt-4o ", "gpt-4o")]
    [TestCase(" gpt-4o", "gpt-4o")]
    [TestCase(" gpt-4o ", "gpt-4o")]
    [TestCase("gpt-4-turbo", "gpt-4-turbo")]
    [TestCase("gpt-4-turbo ", "gpt-4-turbo")]
    [TestCase(" gpt-4-turbo ", "gpt-4-turbo")]
    [TestCase("gpt-4-turbo ", "gpt-4-turbo")]
    [TestCase("", "gpt-4o")]
    [TestCase(" ", "gpt-4o")]
    [TestCase("something", "gpt-4o")]
    [TestCase("test", "gpt-4o")]
    [TestCase("model", "gpt-4o")]
    public void ModelTests(string value, string expected)
    {
        var genericConfiguration = new Dictionary<string, string>
        {
            { "model", value }
        };
        
        var configuration = new OpenAiGpt4oConfiguration(genericConfiguration);
        
        Assert.That(configuration.Model, Is.EqualTo(expected));
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
    [TestCase("", 0.2f)]
    [TestCase(" ", 0.2f)]
    [TestCase("!@#", 0.2f)]
    [TestCase("Test", 0.2f)]
    [TestCase("Temperature", 0.2f)]
    public void TemperatureTests(string value, float expected)
    {
        var genericConfiguration = new Dictionary<string, string>
        {
            { "temperature", value }
        };
        
        var configuration = new OpenAiGpt4oConfiguration(genericConfiguration);
        
        Assert.That(configuration.Temperature, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase("true", true)]
    [TestCase("false", false)]
    [TestCase("True", true)]
    [TestCase("False", false)]
    [TestCase("TRUE", true)]
    [TestCase("FALSE", false)]
    [TestCase(" True", true)]
    [TestCase("False ", false)]
    [TestCase(" True ", true)]
    [TestCase("", false)]
    [TestCase("test", false)]
    [TestCase("something", false)]
    public void RefereeEnabledTests(string value, bool expected)
    {
        var genericConfiguration = new Dictionary<string, string>
        {
            { "refereeEnabled", value }
        };
        
        var configuration = new OpenAiGpt4oConfiguration(genericConfiguration);
        
        Assert.That(configuration.RefereeEnabled, Is.EqualTo(expected));
    }
}