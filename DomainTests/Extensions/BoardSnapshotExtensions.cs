using Domain.Chessboard;

namespace DomainTests.Extensions;

public static class BoardSnapshotExtensions
{
    public static TestSquare[,] ToTestSquares(this BoardSnapshot snapshot)
    {
        var output = new TestSquare[snapshot.BoardSize.Rows, snapshot.BoardSize.Columns];

        for (var row = 0; row < snapshot.BoardSize.Rows; row++)
        for (var column = 0; column < snapshot.BoardSize.Columns; column++)
            output[row, column] = TestSquare.FromSquare(snapshot.Squares[row, column]);

        return output;
    }
}