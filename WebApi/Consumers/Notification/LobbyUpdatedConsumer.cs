using MassTransit;
using Microsoft.AspNetCore.SignalR;
using WebApi.Extensions;
using WebApi.Hubs;
using WebApi.Messages.Notification;
using WebApi.Repository;

namespace WebApi.Consumers.Notification;

public class LobbyUpdatedConsumer(GameLobbyListRepository lobbyListRepository, IHubContext<DashboardHub, DashboardHubClient> dashboardHub, ILogger<LobbyUpdatedConsumer> logger)
    : IConsumer<LobbyUpdated>
{
    public async Task Consume(ConsumeContext<LobbyUpdated> context)
    {
        var lobbies = await lobbyListRepository.GetAll();
        await dashboardHub.Clients.All.LobbiesUpdated(lobbies.ToDto());
        
        logger.LogInformation("UpdateLobbies notification sent!");
    }
}