using Contracts.Dto;
using Domain.Chessboard.Pieces;
using Type = Domain.Chessboard.Pieces.Type;

namespace WebApi.Extensions;

public static class PieceExtensions
{
    public static PieceDto ToDto(this Piece p) => new() {Id = p.Id, Color = p.Color.ToDto(), Type = p.Type.ToDto()};
    public static PieceTypeDto ToDto(this Type pt) => pt switch
    {
        Type.King => PieceTypeDto.King,
        Type.Man => PieceTypeDto.Man,
        _ => throw new ArgumentOutOfRangeException(nameof(pt), pt, null)
    };
}