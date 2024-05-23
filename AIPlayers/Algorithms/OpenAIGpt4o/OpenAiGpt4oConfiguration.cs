using System.Globalization;

namespace AIPlayers.Algorithms.OpenAIGpt4o;

public record OpenAiGpt4oConfiguration
{
    public float Temperature { get; }
    public string Model { get; }
    public bool RefereeEnabled { get; }
    
    private const string TemperatureField = "temperature";
    private const string ModelField = "model";
    private const string RefereeField = "refereeEnabled";
    
    private const float DefaultTemperature = 0.2f;
    private const string DefaultModel = "gpt-4o";
    
    public OpenAiGpt4oConfiguration(Dictionary<string, string> genericConfiguration)
    {
        if (genericConfiguration.TryGetValue(TemperatureField, out var temp) && float.TryParse(temp.Replace(',', '.'), CultureInfo.InvariantCulture, out var temperature))
        {
            Temperature = temperature;
        }
        else
        {
            Temperature = DefaultTemperature;
        }
        
        Model = genericConfiguration.GetValueOrDefault(ModelField, DefaultModel);
        RefereeEnabled = genericConfiguration.TryGetValue(RefereeField, out var refereeEnabled) && bool.TryParse(refereeEnabled, out var referee) && referee;
    }
}