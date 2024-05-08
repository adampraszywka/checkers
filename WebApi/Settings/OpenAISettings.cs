using System.ComponentModel.DataAnnotations;

namespace WebApi.Settings;

public record OpenAISettings
{
    public const string Key = "OpenAi";

    [Required(AllowEmptyStrings = false)]
    public required string ApiKey { get; init; }
}