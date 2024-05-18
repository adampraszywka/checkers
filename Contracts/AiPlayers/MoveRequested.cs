using Contracts.Dto;

namespace Contracts.AiPlayers;

public record MoveRequested(string BoardId, string PlayerId, MoveDto Move);