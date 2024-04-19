using Domain.Chessboard;
using Domain.Chessboard.GameStates;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class MoveLogEntryExtensions
{
    public static MoveLogEntryDto ToDto(this Move move) => new(move.Piece.ToDto(), move.From.ToEntryDto(), move.To.ToEntryDto());
    public static IEnumerable<MoveLogEntryDto> ToDto(this IEnumerable<Move> moves) => moves.Select(x => x.ToDto());
    private static MoveLogPositionDto ToEntryDto(this Position position) => new(position.Row, position.Column, position.Name);

}