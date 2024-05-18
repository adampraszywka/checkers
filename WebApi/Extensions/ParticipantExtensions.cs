using Contracts.Dto;
using Domain.Shared;

namespace WebApi.Extensions;

public static class ParticipantExtensions
{
    public static ParticipantDto ToDto(this Participant p) => new()
    {
        Id = p.Player.Id,
        Bot = p.Player.Type == "AI",
        Color = p.Color.ToDto()
    };
    public static IEnumerable<ParticipantDto> ToDto(this IEnumerable<Participant> p) => p.Select(x => x.ToDto());

}