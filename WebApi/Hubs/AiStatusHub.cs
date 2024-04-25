using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs.Extensions;

namespace WebApi.Hubs;

public class AiStatusHub(ILogger<AiStatusHub> logger) : Hub<AiStatusHubClient>
{
    public override async Task OnConnectedAsync()
    {
        var boardId = Context.BoardId();
        if (boardId is null)
        {
            throw new NotImplementedException();
        }

        var connectionId = Context.ConnectionId;
        await Groups.AddToGroupAsync(connectionId, boardId);
        
        logger.LogInformation("{ConnectionId} connected to AIStatusHub {BoardId}", connectionId, boardId);
    }
}