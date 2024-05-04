using Contracts.Dto;

namespace AIPlayers.Players.AnthropicClaude;

public record AntrophicClaudeGamePlayerGameStateChanged(BoardDto Board, NotifiableParticipantDto Participant);