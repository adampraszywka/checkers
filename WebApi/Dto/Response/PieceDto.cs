using Domain.Shared;
using Type = Domain.Chessboard.Pieces.Type;

namespace WebApi.Dto.Response;

public class PieceDto
{
    public required string Id { get; init; }
    public required Color Color { get; init; }
    public required Type Type { get; init; }
}