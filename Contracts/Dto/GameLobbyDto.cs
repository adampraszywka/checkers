namespace Contracts.Dto;

public record GameLobbyDto
{
    public required string Id { get; init; }
    public required string Name { get; init; } 
    public required string? BoardId { get; init; } 
    public required int Players { get; init; }
    public required int MaxPlayers { get; init; }
    public required LobbyStatusDto Status { get; init; }
    public required IEnumerable<ParticipantDto> Participants { get; init; }
}