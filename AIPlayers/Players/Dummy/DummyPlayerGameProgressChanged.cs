using Contracts.Dto;

namespace AIPlayers.Players.Dummy;

public record DummyPlayerGameProgressChanged(BoardDto Board, NotifiableParticipantDto Participant);