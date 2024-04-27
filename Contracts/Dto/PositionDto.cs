using Domain.Shared;

namespace Contracts.Dto;

public record PositionDto(int Row, int Column)
{
    public static PositionDto FromName(string name)
    {
        const int charA = 65;
        const int charZ = 90;
        
        if (name.Length != 2)
        {
            throw new ArgumentException();
        }

        var columnChar = name[0];
        var rowChar = name[1];
        
        if (columnChar < charA || columnChar > charZ)
        {
            throw new ArgumentException();
        }

        if (!int.TryParse(rowChar.ToString(), out var rowParsed))
        {
            throw new ArgumentException();
        }

        var column = columnChar - charA;
        var row = rowParsed - 1;
        
        return new PositionDto(row, column);
    }
}