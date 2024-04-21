using WebApi.Dto.Response;

namespace Contracts.Dto;

public record MoveDto(PositionDto From, PositionDto To);