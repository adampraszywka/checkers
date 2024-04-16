using Domain.Lobby;
using Domain.Shared;

namespace WebApi.Dto.Response;

public record GameLobbyDto
{
    public required string Id { get; init; }
    public required string Name { get; init; } 
    public required string? GameId { get; init; } 
    public required int Players { get; init; }
    public required int MaxPlayers { get; init; }
    public required GameLobby.LobbyStatus Status { get; init; }
    public required IEnumerable<ParticipantDto> Participants { get; init; }
}

public record ParticipantDto
{
    public required string Name { get; init; }
    public required Color Color { get; init; }
}