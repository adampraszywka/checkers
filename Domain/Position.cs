namespace Domain;

public record Position(int Row, int Column)
{
    public const int A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7;
    public const int R1 = 0, R2 = 1, R3 = 2, R4 = 3, R5 = 4, R6 = 5, R7 = 6, R8 = 7;
    
    public (int Row, int Column) Coordinates = (Column, Row);
    public bool IsWithinBoard(int boardSize) => Row >= 0 && Column >= 0 && Row < boardSize && Column < boardSize;
}