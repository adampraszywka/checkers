using System.Globalization;
using AIPlayers.MessageHub;

namespace AIPlayers.Algorithms.Llama;

public record Laama31Configuration
{
    public float Temperature { get; }
    
    private const string TemperatureField = "temperature";
    private const float DefaultTemperature = 0.2f;
    
    public Laama31Configuration(AiAlgorithmConfiguration configuration)
    {
        if (configuration.Entries.TryGetValue(TemperatureField, out var temp) && float.TryParse(temp.Replace(',', '.'), CultureInfo.InvariantCulture, out var temperature))
        {
            Temperature = temperature;
        }
        else
        {
            Temperature = DefaultTemperature;
        }

    }
}