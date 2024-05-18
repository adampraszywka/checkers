using Microsoft.AspNetCore.SignalR;
using WebApi.Players;

namespace WebApi.Hubs.Extensions;

public static class HubExtensions
{
    private const string PlayerIdKey = "playerId";
    private const string BoardIdKey = "boardId";
    private const string LobbyIdKey = "lobbyId";

    public static string? BoardId(this HubCallerContext context) => context.FromQueryString(BoardIdKey).FirstOrDefault();
    public static string? LobbyId(this HubCallerContext context) => context.FromQueryString(LobbyIdKey).FirstOrDefault();
    
    public static SignalRPlayer? Player(this HubCallerContext context)
    {
        var playerId = context.FromQueryString(PlayerIdKey).FirstOrDefault();
        return playerId is not null ? new SignalRPlayer(playerId) : null;
    }

    public static IEnumerable<string> FromQueryString(this HubCallerContext context, string key)
    {
        var httpContext = context.GetHttpContext();
        if (httpContext is null)
        {
            return Enumerable.Empty<string>();
        }

        if (!httpContext.Request.Query.TryGetValue(key, out var values))
        {
            return Enumerable.Empty<string>();
        }

        return values;
    }
}