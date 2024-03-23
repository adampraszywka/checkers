using Domain.Configurations;

namespace Domain;

public record Position(int Row, int Column)
{
    public const int A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7;
    public const int R1 = 0, R2 = 1, R3 = 2, R4 = 3, R5 = 4, R6 = 5, R7 = 6, R8 = 7;
    
    public bool IsWithinBoard(BoardSize boardSize) => Row >= 0 && Column >= 0 && Row < boardSize.Rows && Column < boardSize.Columns;

    public Position RightForward() => new(Row + 1, Column + 1);
    public Position RightBackward() => new(Row - 1, Column + 1);
    public Position LeftForward() => new(Row + 1, Column - 1);
    public Position LeftBackward() => new(Row - 1, Column - 1);
}