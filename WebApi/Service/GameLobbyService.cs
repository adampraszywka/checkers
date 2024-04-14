using Domain.Lobby;
using Domain.Shared;
using FluentResults;
using MassTransit;
using WebApi.Messages.Notification;
using WebApi.Service.Errors;

namespace WebApi.Service;

public class GameLobbyService(GameLobbyRepository lobbyRepository, IPublishEndpoint publishEndpoint)
{
    public async Task<Result<GameLobby>> Get(string lobbyId)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return Result.Fail(new LobbyNotFound(lobbyId));
        }

        return Result.Ok(lobby);
    }

    public async Task<Result<GameLobby>> Create(Player player, string name)
    {
        var id = Guid.NewGuid().ToString();
        var lobby = new GameLobby(id, name);

        var result = lobby.Join(player);

        if (result.IsFailed)
        {
            return Result.Fail(new LobbyCreationFailed(result.Errors));
        }

        await lobbyRepository.Save(lobby);
        await LobbyUpdateNotification(lobby);
        
        return Result.Ok(lobby);
    }

    public async Task<Result<GameLobby>> Join(string lobbyId, Player player)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return Result.Fail(new LobbyNotFound(lobbyId));
        }

        var result = lobby.Join(player);
        if (result.IsFailed)
        {
            return Result.Fail(new LobbyJoinFailed(result.Errors));
        }

        await lobbyRepository.Save(lobby);
        await LobbyUpdateNotification(lobby);

        return Result.Ok(lobby);
    }

    private Task LobbyUpdateNotification(GameLobby lobby) => publishEndpoint.Publish(new LobbyUpdated(lobby.Id));
}