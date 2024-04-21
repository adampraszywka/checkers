namespace Contracts.Dto;

public record MoveLogEntryDto(PieceDto Piece, MoveLogPositionDto From, MoveLogPositionDto To);