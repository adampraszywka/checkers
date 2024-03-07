namespace Extension;

public static class RectangularArrayExtensions
{
    public static int Columns<T>(this T[,] source) => source.GetLength(0);
    public static int Rows<T>(this T[,] source) => source.GetLength(1);
    
    public static IEnumerable<T> Flatten<T>(this T[,] source)
    {
        return source.Cast<T>();
    }

    public static TY[,] Transform<T, TY>(this T[,] source, Func<T, TY> callback)
    {
        var rows = source.Columns();
        var columns = source.Rows();

        var result = new TY[rows, columns];

        for (var row = 0; row < rows; row++)
        {
            for(var column = 0; column < columns; column++)
            {
                result[row, column] = callback(source[row, column]);
            }
        }

        return result;
    }
    
    public static T[,] ReverseRows<T>(this T[,] source)
    {
        var rows = source.Columns();
        var columns = source.Rows();

        var result = new T[rows, columns];
        
        for (var row = 0; row < rows; row++)
        {
            for(var column = 0; column < columns; column++)
            {
                result[rows - row - 1, column] = source[row, column];
            }
        }

        return result;
    }

}