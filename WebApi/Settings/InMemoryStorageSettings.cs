namespace WebApi.Settings;

public record InMemoryStorageSettings
{
    public const string Key = "InMemoryStorage";
    public TimeSpan TimeToLive { get; init; }
}