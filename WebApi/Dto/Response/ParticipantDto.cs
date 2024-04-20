using Domain.Shared;

namespace WebApi.Dto.Response;

public record ParticipantDto
{
    public required string Id { get; init; }
    public required Color Color { get; init; }
}