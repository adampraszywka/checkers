using Contracts.Dto;
using Domain.Lobby;
using FluentResults;
using Microsoft.AspNetCore.SignalR;
using WebApi.Dto;
using WebApi.Dto.Response;
using WebApi.Extensions;
using WebApi.Hubs.Extensions;
using WebApi.Repository;
using WebApi.Service;

namespace WebApi.Hubs;

public class DashboardHub(GameLobbyService lobbyService, GameLobbyListRepository lobbyListRepository, ILogger<DashboardHub> logger) : Hub<DashboardHubClient>()
{
    public override async Task OnConnectedAsync()
    {
        var player = Context.Player();
        
        if (player is null)
        {
            throw new NotImplementedException();
        }

        var lobbies = await lobbyListRepository.GetAll();
        await Clients.Caller.LobbiesUpdated(lobbies.ToDto());
    }

    public async Task<ActionResult<GameLobbyDto>> CreateLobby(string lobbyName)
    {
        var player = Context.Player();
        if (player is null)
        {
            return AuthError<GameLobbyDto>();
        }

        var result = await lobbyService.Create(player, lobbyName);
        return HandleResult(result);
    }

    public async Task<ActionResult<GameLobbyDto>> JoinLobby(string lobbyId)
    {
        var player = Context.Player();
        if (player is null)
        {
            return AuthError<GameLobbyDto>();
        }

        var result = await lobbyService.Join(lobbyId, player);
        return HandleResult(result);
    }

    private static ActionResult<GameLobbyDto> HandleResult(Result<GameLobby> result)
    {
        if (result.IsFailed)
        {
            return ActionResult<GameLobbyDto>.FromErrors(result.Errors);
        }

        return ActionResult<GameLobbyDto>.Success(result.Value.ToDto());
    }
    
    private static ActionResult<T> AuthError<T>() where T : class
    {
        return ActionResult<T>.Failed("Authorization error!");
    }
}