using Contracts.Dto;
using Domain.Lobby;

namespace WebApi.Extensions;

public static class GameLobbyExtensions
{
    public static GameLobbyDto ToDto(this GameLobby lobby)
    {
        return new()
        {
            Id = lobby.Id,
            Name = lobby.Name,
            BoardId = lobby.BoardId,
            Players = lobby.Participants.Count(),
            MaxPlayers = lobby.MaxPlayers,
            Status = lobby.Status.ToDto(),
            Participants = lobby.Participants.ToDto()
        };
    }

    public static IEnumerable<GameLobbyDto> ToDto(this IEnumerable<GameLobby> gameLobbies)
    {
        return gameLobbies.Select(x => x.ToDto());
    }
}