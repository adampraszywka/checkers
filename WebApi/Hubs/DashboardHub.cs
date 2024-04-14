using Microsoft.AspNetCore.SignalR;
using WebApi.Dto.Response;

namespace WebApi.Hubs;

public class DashboardHub : Hub<DashboardHubClient>
{
    public async Task UpdateLobbies(IEnumerable<GameLobbyDto> gameLobbies)
    {
        await Clients.All.LobbiesUpdated(gameLobbies);
    }
}