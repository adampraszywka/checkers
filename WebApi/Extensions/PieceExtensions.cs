using Domain.Chessboard.Pieces;
using WebApi.Dto.Response;

namespace WebApi.Extensions;

public static class PieceExtensions
{
    public static PieceDto ToDto(this Piece p) => new() {Id = p.Id, Color = p.Color, Type = p.Type};
}