using Domain.Chessboard;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class SquareSnapshotExtensions
{
    public static SquareSnapshotDto ToDto(this SquareSnapshot s) =>
        new() {Id = s.Id, Piece = s.Piece?.ToDto(), Position = s.Position.ToDto()};
}