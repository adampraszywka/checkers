using Domain.Chessboard;

namespace WebApi.Dto;

public record PositionDto(int Row, int Column)
{
    public Position Position => new(Row, Column);
}