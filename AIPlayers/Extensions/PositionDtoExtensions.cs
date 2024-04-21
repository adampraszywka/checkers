using Contracts.Dto;

namespace AIPlayers.Extensions;

public static class PositionDtoExtensions
{
    public static string ToCoordinates(this PositionDto position) => $"({position.Row},{position.Column})";
}