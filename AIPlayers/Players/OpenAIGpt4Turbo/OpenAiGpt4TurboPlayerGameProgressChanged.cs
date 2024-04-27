using Contracts.Dto;

namespace AIPlayers.Players.OpenAIGpt4Turbo;

public record OpenAiGpt4TurboPlayerGameProgressChanged(BoardDto Board, NotifiableParticipantDto Participant);