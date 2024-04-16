using Domain.Chessboard;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class BoardExtensions
{
    public static BoardDto ToDto(this Board board) => new(board);
}