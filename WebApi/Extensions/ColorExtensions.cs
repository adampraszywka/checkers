using Contracts.Dto;
using Domain.Shared;

namespace WebApi.Extensions;

public static class ColorExtensions
{
    public static ColorDto ToDto(this Color color)
    {
        return color switch
        {
            Color.Black => ColorDto.Black,
            Color.White => ColorDto.White,
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
    }
}