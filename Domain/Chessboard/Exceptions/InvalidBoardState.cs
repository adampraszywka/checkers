namespace Domain.Chessboard.Exceptions;

public class InvalidBoardState : Exception
{
    private InvalidBoardState(string message) : base(message)
    {
    }

    public static InvalidBoardState BrokenPieceSquareConnection =>
        new("Piece-Board connection has to be bidirectional");

    public static InvalidBoardState SquareIsNotEmpty => new("Cannot move piece to not empty square");
    public static InvalidBoardState SquareIsEmpty => new("Cannot remove piece from empty field");
}