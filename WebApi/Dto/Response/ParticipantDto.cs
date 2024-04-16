using Domain.Shared;

namespace WebApi.Dto.Response;

public record ParticipantDto
{
    public required string Name { get; init; }
    public required Color Color { get; init; }
}