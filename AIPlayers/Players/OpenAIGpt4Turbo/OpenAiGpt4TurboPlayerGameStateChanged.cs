using Contracts.Dto;

namespace AIPlayers.Players.OpenAIGpt4Turbo;

public record OpenAiGpt4TurboPlayerGameStateChanged(BoardDto Board, NotifiableParticipantDto Participant);