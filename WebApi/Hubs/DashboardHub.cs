using Contracts.Dto;
using Domain.Lobby;
using FluentResults;
using Microsoft.AspNetCore.SignalR;
using WebApi.Extensions;
using WebApi.Hubs.Extensions;
using WebApi.Repository;
using WebApi.Results;
using WebApi.Service;
using WebApi.Service.Errors;

namespace WebApi.Hubs;

public class DashboardHub(GameLobbyService lobbyService, GameLobbyListRepository lobbyListRepository, ILogger<DashboardHub> logger) : Hub<DashboardHubClient>()
{
    private const string LobbyCreateFailed = "LOBBY_CREATE_FAILED";
    private const string LobbyJoinFailed = "LOBBY_JOIN_FAILED";
    private const string LobbyJoinFailedPlayerAlreadyInTheLobby = "LOBBY_JOIN_FAILED_PLAYER_ALREADY_IN_THE_LOBBY";
    private const string AuthorizationError = "AUTHORIZATION_ERROR";

    
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

    public async Task<NullableActionResult<GameLobbyDto>> CreateLobby(string lobbyName)
    {
        var player = Context.Player();
        if (player is null)
        {
            return AuthError<GameLobbyDto>();
        }

        var result = await lobbyService.Create(player, lobbyName);
        return HandleResult(result, LobbyCreateFailed);
    }

    public async Task<NullableActionResult<GameLobbyDto>> JoinLobby(string lobbyId)
    {
        var player = Context.Player();
        if (player is null)
        {
            return AuthError<GameLobbyDto>();
        }

        var result = await lobbyService.Join(lobbyId, player);
        
        if (result.HasError<LobbyJoinFailedPlayerAlreadyInLobby>())
        {
            return NullableActionResult<GameLobbyDto>.FromErrors(result.Errors, LobbyJoinFailedPlayerAlreadyInTheLobby);
        }
        
        if (result.IsFailed)
        {
            return NullableActionResult<GameLobbyDto>.FromErrors(result.Errors, LobbyJoinFailed);
        }

        return NullableActionResult<GameLobbyDto>.Success(result.Value.ToDto());
    }

    private static NullableActionResult<GameLobbyDto> HandleResult(Result<GameLobby> result, string errorCode)
    {
        if (result.IsFailed)
        {
            return NullableActionResult<GameLobbyDto>.FromErrors(result.Errors, errorCode);
        }

        return NullableActionResult<GameLobbyDto>.Success(result.Value.ToDto());
    }
    
    private static NullableActionResult<T> AuthError<T>() where T : class
    {
        return NullableActionResult<T>.Failed("Authorization error!", AuthorizationError);
    }
}