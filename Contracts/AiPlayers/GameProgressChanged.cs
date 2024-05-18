using Contracts.Dto;

namespace Contracts.AiPlayers;

public record GameProgressChanged(BoardDto Board, ParticipantDto Participant);