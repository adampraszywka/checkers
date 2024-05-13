using Contracts.Dto;

namespace AIPlayers.Players.OpenAIGpt4o;

public record OpenAiGpt4oPlayerGameStateChanged(BoardDto Board, NotifiableParticipantDto Participant);