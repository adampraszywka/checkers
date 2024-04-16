using Domain.Shared;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class ParticipantExtensions
{
    public static ParticipantDto ToDto(this Participant p) => new() {Name = p.Player.Id, Color = p.Color};
}