using Microsoft.AspNetCore.SignalR;
using WebApi.Dto;
using WebApi.Dto.Response;
using WebApi.Extensions;
using WebApi.Hubs.Extensions;
using WebApi.Service;

namespace WebApi.Hubs;

public class LobbyHub(GameLobbyService lobbyService) : Hub<LobbyHubClient>
{
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

    public async Task<ActionResult<BoardDto>> Close()
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
            return ActionResult<BoardDto>.FromErrors(result.Errors);
        }

        var board = result.Value;
        return ActionResult<BoardDto>.Success(board.ToDto());
    }
    
    private static ActionResult<T> AuthError<T>() where T : class
    {
        return ActionResult<T>.Failed("Authorization error!");
    }
}