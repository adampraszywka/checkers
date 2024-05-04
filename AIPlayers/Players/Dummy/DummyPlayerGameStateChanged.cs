using Contracts.Dto;

namespace AIPlayers.Players.Dummy;

public record DummyPlayerGameStateChanged(BoardDto Board, NotifiableParticipantDto Participant);