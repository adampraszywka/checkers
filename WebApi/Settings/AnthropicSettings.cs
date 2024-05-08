using System.ComponentModel.DataAnnotations;

namespace WebApi.Settings;

public record AnthropicSettings
{
    public const string Key = "Antropic";
    
    [Required(AllowEmptyStrings = false)]
    public required string ApiKey { get; init; }
}