namespace Contracts.AiPlayers;

public record AiPlayerStatusUpdated(string BoardId, IEnumerable<AiPlayerStatus> Entries);

public record AiPlayerStatus(long Timestamp, Kind Kind, string Context, string Data)
{
    public static AiPlayerStatus Command(string context, string data) => new(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), Kind.Command, context, data);
    public static AiPlayerStatus Successful(string context, string data) => new(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), Kind.ResultSuccessful, context, data);
    public static AiPlayerStatus Failed(string context, string data) => new(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), Kind.ResultFailed, context, data);
}

public enum Kind
{
    Command, ResultSuccessful, ResultFailed
}