namespace Contracts.Dto;

public record NotifiableParticipantDto
{
    public required string Id { get; init; }
    public required string Type { get; init; }
    public required ColorDto Color { get; init; }
}