namespace Domain.Configurations;

public record BoardSize
{
    public BoardSize(int rows, int columns)
    {
        if (rows < 1)
        {
            throw new ArgumentException();
        }

        if (columns < 1)
        {
            throw new ArgumentException();
        }
        
        Rows = rows;
        Columns = columns;
    }

    public int Rows { get; } 
    public int Columns { get; }
}