using Domain.Shared;

namespace WebApi.Dto.Response;

public record NotifiableParticipantDto
{
    public required string Id { get; init; }
    public required string Type { get; init; }
    public required Color Color { get; init; }
}