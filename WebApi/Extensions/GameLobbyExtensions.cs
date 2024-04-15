using Domain.Lobby;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class GameLobbyExtensions
{
    public static GameLobbyDto ToDto(this GameLobby lobby) => new(lobby);

    public static IEnumerable<GameLobbyDto> ToDto(this IEnumerable<GameLobby> gameLobbies)
    {
        return gameLobbies.Select(x => x.ToDto());
    }
}