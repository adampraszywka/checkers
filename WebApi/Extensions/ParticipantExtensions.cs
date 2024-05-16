using Contracts.Dto;
using Domain.Chessboard;
using Domain.Shared;

namespace WebApi.Extensions;

public static class ParticipantExtensions
{
    public static ParticipantDto ToDto(this Participant p) => new() {Id = p.Player.Id, Color = p.Color.ToDto(), Bot = p.Player.Bot};
    public static IEnumerable<ParticipantDto> ToDto(this IEnumerable<Participant> p) => p.Select(x => x.ToDto());

    
    public static NotifiableParticipantDto ToNotifiableDto(this Participant p) => 
        new() {Id = p.Player.Id, Type = p.Player.Type, Color = p.Color.ToDto()};

    public static IEnumerable<NotifiableParticipantDto> ToNotifiableDto(this Participants p) =>
        p.List.Select(x => x.ToNotifiableDto());


}