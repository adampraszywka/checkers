using AIPlayers.Players;
using Contracts.Dto;

namespace WebApi.Extensions;

public static class AIPlayerExtensions
{
    public static AIPlayerDto ToDto(this AIPlayer player) => new(player.Algorithm, player.Name);
    public static IEnumerable<AIPlayerDto> ToDto(this IEnumerable<AIPlayer> players) => players.Select(x => x.ToDto());
}