using Contracts.Dto;
using Domain.Chessboard;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class PositionExtensions
{
    public static PositionDto ToDto(this Position position) => new(position.Row, position.Column);

    public static Position ToPosition(this PositionDto dto) => new(dto.Row, dto.Column);
}