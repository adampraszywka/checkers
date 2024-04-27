namespace Domain.Shared;

public static class PositionMapping
{
    public static string Name(int column, int row) => $"{MapColumn(column)}{row + 1}";
    private static char MapColumn(int columnNumber)
    {
        const int charA = 65;
        const int charZ = 90;
        const int supportedColumns = charZ - charA;

        if (columnNumber > supportedColumns)
        {
            return '?';
        }

        return (char) (columnNumber + charA);
    }
}