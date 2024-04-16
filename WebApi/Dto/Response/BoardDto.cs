using Domain.Chessboard;
using Domain.Chessboard.GameStates;
using Domain.Shared;
using Extension;

namespace WebApi.Dto.Response;

public record BoardDto
{
    public required string Id { get; init; }
    public required int Columns { get; init; }
    public required int Rows { get; init; }
    public required IEnumerable<IEnumerable<SquareSnapshotDto>> Squares { get; init; }
    public required IEnumerable<MoveDto> MoveLog { get; init; }
    public required Color CurrentPlayer { get; init; }
}