namespace Extension;

public static class RectangularArrayExtensions
{
    public static IEnumerable<T> Flatten<T>(this T[,] source)
    {
        return source.Cast<T>();
    }

    public static TY[,] Transform<T, TY>(this T[,] source, Func<T, TY> callback)
    {
        var rows = source.GetLength(0);
        var columns = source.GetLength(1);

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
}