
namespace Contracts.Dto;

public class PieceDto
{
    public required string Id { get; init; }
    public required ColorDto Color { get; init; }
    public required PieceTypeDto Type { get; init; }
}