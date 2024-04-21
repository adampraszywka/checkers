using Contracts.Dto;
using Contracts.Players;

namespace WebApi.Players;

public class AiPlayers
{
    public static readonly IEnumerable<AiPlayer> List = [
        new(AIDummyPlayer.TypeValue, nameof(AIDummyPlayer))
    ];
}