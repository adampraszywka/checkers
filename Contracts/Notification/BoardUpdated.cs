using Contracts.Dto;

namespace Contracts.Notification;

public record BoardUpdated(BoardDto Board, IEnumerable<ParticipantDto> NotifiableParticipants);