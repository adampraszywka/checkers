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
    
    private const string ModelGpt4Turbo = "gpt-4-turbo";
    private const string ModelGpt4o = "gpt-4o";
    
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

        Model = ParseModel(genericConfiguration.GetValueOrDefault(ModelField));
        RefereeEnabled = genericConfiguration.TryGetValue(RefereeField, out var refereeEnabled) && bool.TryParse(refereeEnabled, out var referee) && referee;
    }

    private string ParseModel(string? value)
    {
        var trimmedValue = value?.Trim();
        return trimmedValue is ModelGpt4Turbo or ModelGpt4o ? trimmedValue : ModelGpt4o;
    }
}