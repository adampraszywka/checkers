using Contracts.Dto;
using Microsoft.AspNetCore.SignalR;
using WebApi.Extensions;
using WebApi.Hubs.Extensions;
using WebApi.Players;
using WebApi.Results;
using WebApi.Service;

namespace WebApi.Hubs;

public class LobbyHub(GameLobbyService lobbyService) : Hub<LobbyHubClient>
{
    private const string ClosedFailed = "LOBBY_CLOSED_FAILED";
    private const string AddAiPlayerFailed = "LOBBY_ADD_AI_PLAYER_FAILED";
    private const string AuthorizationError = "AUTHORIZATION_ERROR";
    
    public override async Task OnConnectedAsync()
    {
        var player = Context.Player();
        var lobbyId = Context.LobbyId();
        
        if (player is null || lobbyId is null)
        {
            throw new NotImplementedException();
        }
        
        var lobbyResult = await lobbyService.Get(lobbyId);
        if (lobbyResult.IsFailed)
        {
            throw new NotImplementedException();
        }

        var lobby = lobbyResult.Value;
        var groupName = lobby.Id;
        var connectionId = Context.ConnectionId;
        
        await Groups.AddToGroupAsync(connectionId, groupName);
        await Clients.Caller.LobbyUpdated(lobby.ToDto());
    }

    public async Task<NullableActionResult<BoardDto>> Close()
    {
        var player = Context.Player();
        var lobbyId = Context.LobbyId();

        if (player is null || lobbyId is null)
        {
            return AuthError<BoardDto>();
        }
        
        var result = await lobbyService.Close(lobbyId, player);
        if (result.IsFailed)
        {
            return NullableActionResult<BoardDto>.FromErrors(result.Errors, ClosedFailed);
        }

        var board = result.Value;
        return NullableActionResult<BoardDto>.Success(board.ToDto());
    }
    
    public Task<IEnumerable<AiPlayer>> ListAiPlayers()
    {
        return Task.FromResult(PlayerFactory.AvailableAiPlayers);
    }

    public async Task<NullableActionResult<GameLobbyDto>> AddAiPlayer(string aiPlayerType)
    {
        var lobbyId = Context.LobbyId();

        // Not sure about auth here. 
        // Maybe we should check here if caller belongs to the lobby
        // on the other hand in the future lobby AI vs AI games could be possible
        // then we should allow this action without checking the player
        // TODO: Think about it
        if (lobbyId is null)
        {
            return AuthError<GameLobbyDto>();
        }

        var result = await lobbyService.AddAiPlayer(lobbyId, aiPlayerType);
        if (result.IsFailed)
        {
            return NullableActionResult<GameLobbyDto>.FromErrors(result.Errors, AddAiPlayerFailed);
        }

        var gameLobby = result.Value;
        return NullableActionResult<GameLobbyDto>.Success(gameLobby.ToDto());
    }
    
    private static NullableActionResult<T> AuthError<T>() where T : class
    {
        return NullableActionResult<T>.Failed("Authorization error!", AuthorizationError);
    }
}