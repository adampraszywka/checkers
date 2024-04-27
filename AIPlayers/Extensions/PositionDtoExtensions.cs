using Contracts.Dto;
using Domain.Shared;

namespace AIPlayers.Extensions;

public static class PositionDtoExtensions
{
    public static string ToCoordinates(this PositionDto position) => $"({position.Row},{position.Column})";
    public static string ToName(this PositionDto dto) => PositionMapping.Name(dto.Column, dto.Row);
}