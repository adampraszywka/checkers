using Domain.Pieces;

namespace Domain.PieceMoves.Classic;

public class ClassicBlackManMoves : PieceMove
{
    // To be refactored later
    // So far it's a copy & paste of white man moves
    // Once most of test cases are ready, refactoring will be needed
    public IEnumerable<Move> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        var moves = new List<Move>();
        
        // To the left
        var newPosition1 = currentPosition.LeftBackward();
        if (newPosition1.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare1 = boardSnapshot.Squares[newPosition1.Row, newPosition1.Column];
            if (newSquare1.Piece is not null && newPosition1.Column > 0 && newSquare1.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = newPosition1.LeftBackward();
                var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                if (newSquareAfterCapture.Piece is not null)
                {
                    //TODO: Square is already occupied
                }

                moves.Add(new Move(newPositionAfterCapture, new[] {newPosition1}, 1));
            }
            else if (newSquare1.Piece is null)
            {
                moves.Add(new Move(newPosition1, new[] {newPosition1}, 0));
            }
        }
        
        //To the right
        var newPosition2 = currentPosition.RightBackward();
        if (newPosition2.IsWithinBoard(boardSnapshot.BoardSize))
        {
            var newSquare2 = boardSnapshot.Squares[newPosition2.Row, newPosition2.Column];
            if (newSquare2.Piece is not null && newSquare2.Piece.Color == Color.White)
            {
                var newPositionAfterCapture = newPosition2.RightBackward();
                var newSquareAfterCapture = boardSnapshot.Squares[newPositionAfterCapture.Row, newPositionAfterCapture.Column];
                if (newSquareAfterCapture.Piece is not null)
                {
                    //TODO: Square is already occupied
                }
                
                moves.Add(new Move(newPositionAfterCapture, new[] {newPosition2}, 1));
            }
            else if (newSquare2.Piece is null)
            {
                moves.Add(new Move(newPosition2, new[] {newPosition2}, 0));

            }
        }
        
        return moves.Count > 0 ? moves.Where(x => x.CapturedPieces == moves.Max(x => x.CapturedPieces)) : moves;
    }
}