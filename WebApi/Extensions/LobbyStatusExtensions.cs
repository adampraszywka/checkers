using Contracts.Dto;
using Domain.Lobby;

namespace WebApi.Extensions;

public static class LobbyStatusExtensions
{
    public static LobbyStatusDto ToDto(this GameLobby.LobbyStatus lobbyStatus) => lobbyStatus switch
    {
        GameLobby.LobbyStatus.WaitingForPlayers => LobbyStatusDto.WaitingForPlayers,
        GameLobby.LobbyStatus.Closed => LobbyStatusDto.Closed,
        GameLobby.LobbyStatus.ReadyToStart => LobbyStatusDto.ReadyToStart,
        _ => throw new ArgumentOutOfRangeException(nameof(lobbyStatus), lobbyStatus, null)
    };
}