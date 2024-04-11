using Domain.Chessboard.Configurations;

namespace Domain.Chessboard;

public record Position(int Row, int Column)
{
    public const int A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7;
    public const int R1 = 0, R2 = 1, R3 = 2, R4 = 3, R5 = 4, R6 = 5, R7 = 6, R8 = 7;

    public static Position A1 => new(0, 0);
    public static Position C1 => new(0, 2);
    public static Position E1 => new(0, 4);
    public static Position G1 => new(0, 6);
    public static Position B2 => new(1, 1);
    public static Position D2 => new(1, 3);
    public static Position F2 => new(1, 5);
    public static Position H2 => new(1, 7);
    public static Position A3 => new(2, 0);
    public static Position C3 => new(2, 2);
    public static Position E3 => new(2, 4);
    public static Position G3 => new(2, 6);
    public static Position B4 => new(3, 1);
    public static Position D4 => new(3, 3);
    public static Position F4 => new(3, 5);
    public static Position H4 => new(3, 7);
    public static Position A5 => new(4, 0);
    public static Position C5 => new(4, 2);
    public static Position E5 => new(4, 4);
    public static Position G5 => new(4, 6);
    public static Position B6 => new(5, 1);
    public static Position D6 => new(5, 3);
    public static Position F6 => new(5, 5);
    public static Position H6 => new(5, 7);
    public static Position A7 => new(6, 0);
    public static Position C7 => new(6, 2);
    public static Position E7 => new(6, 4);
    public static Position G7 => new(6, 6);
    public static Position B8 => new(7, 1);
    public static Position D8 => new(7, 3);
    public static Position F8 => new(7, 5);
    public static Position H8 => new(7, 7);

    public bool IsWithinBoard(BoardSize boardSize)
    {
        return Row >= 0 && Column >= 0 && Row < boardSize.Rows && Column < boardSize.Columns;
    }

    public Position RightForward()
    {
        return new Position(Row + 1, Column + 1);
    }

    public Position RightBackward()
    {
        return new Position(Row - 1, Column + 1);
    }

    public Position LeftForward()
    {
        return new Position(Row + 1, Column - 1);
    }

    public Position LeftBackward()
    {
        return new Position(Row - 1, Column - 1);
    }

    public string Name => $"{MapColumn(Column)}{Row + 1}";
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