using WebApi.Dto.Response;

namespace WebApi.Messages.Notification;

public record BoardUpdated(BoardDto Board, IEnumerable<NotifiableParticipantDto> NotifiableParticipants);