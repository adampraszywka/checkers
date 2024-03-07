using Domain;

namespace DomainTests.Extensions;

public static class BoardSnapshotExtensions
{
    public static TestSquare[,] ToTestSquares(this BoardSnapshot snapshot)
    {
        var output = new TestSquare[snapshot.Rows, snapshot.Columns];
        
        for (var row = 0; row < snapshot.Rows; row++)
        {
            for (var column = 0; column < snapshot.Columns; column++)
            {
                output[row, column] = TestSquare.FromSquare(snapshot.Squares[row, column]);
            }
        }

        return output;
    }
}