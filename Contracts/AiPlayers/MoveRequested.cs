using Contracts.Dto;

namespace Contracts.AiPlayers;

public record MoveRequested(string BoardId, PlayerDto Player, MoveDto Move);