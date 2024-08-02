using System.ComponentModel.DataAnnotations;

namespace WebApi.Settings;

public class LlamaSettings
{
    public const string Key = "Llama";
    
    [Required(AllowEmptyStrings = false)]
    public required string ApiKey { get; init; }
}