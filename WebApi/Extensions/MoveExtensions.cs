using Domain.Chessboard.GameStates;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class MoveExtensions
{
    public static MoveDto ToDto(this Move move) => new(move.From.ToDto(), move.To.ToDto());
    public static IEnumerable<MoveDto> ToDto(this IEnumerable<Move> moves) => moves.Select(x => x.ToDto());
}