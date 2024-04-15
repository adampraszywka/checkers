using Microsoft.AspNetCore.SignalR;
using WebApi.Players;

namespace WebApi.Hubs.Extensions;

public static class HubExtensions
{
    private const string PlayerIdKey = "PlayerId";
    
    public static SignalRPlayer? GetPlayer(this HubCallerContext context)
    {
        var httpContext = context.GetHttpContext();
        if (httpContext is null)
        {
            return null;
        }

        if (!httpContext.Request.Query.TryGetValue(PlayerIdKey, out var values))
        {
            return null;
        }

        var playerId = values.FirstOrDefault();
        if (playerId is null)
        {
            return null;
        }

        return new SignalRPlayer(playerId);
    }
}