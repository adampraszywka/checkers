namespace WebApi.Dto.Response;

public class SquareSnapshotDto
{
    public required string Id { get; init; }
    public required PositionDto Position { get; init; }
    public required PieceDto? Piece { get; init; }
}