namespace WebApi.Dto.Response;

public record MoveLogEntryDto(PieceDto Piece, MoveLogPositionDto From, MoveLogPositionDto To);