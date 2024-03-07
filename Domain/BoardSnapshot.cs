namespace Domain;

public record BoardSnapshot(SquareSnapshot[,] Squares)
{
    public int Rows => Squares.GetLength(0);
    public int Columns => Squares.GetLength(1);
}