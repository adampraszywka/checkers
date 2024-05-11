namespace Domain.Chessboard.PieceMoves.Classic;

public class ClassicWhiteKingMoves : PieceMove
{
    // To be refactored later once all cases are implemented
    public IEnumerable<PossibleMove> PossibleMoves(Position currentPosition, BoardSnapshot boardSnapshot)
    {
        var result = new List<PossibleMove>();

        {
            var affectedSquaresRightForward = new List<Position>();
            var positionRightForward = currentPosition;
            while (positionRightForward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionRightForward = positionRightForward.RightForward();
                if (positionRightForward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionRightForward);
                    if (piece is not null)
                    {
                        break;
                    }

                    affectedSquaresRightForward.Add(positionRightForward);
                    var move = new PossibleMove(positionRightForward, new List<Position>(affectedSquaresRightForward), 0);
                    result.Add(move);
                }
            }
        }

        {
            var affectedSquaresLeftForward = new List<Position>();
            var positionLeftForward = currentPosition;
            while (positionLeftForward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionLeftForward = positionLeftForward.LeftForward();
                if (positionLeftForward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionLeftForward);
                    if (piece is not null)
                    {
                        break;
                    }

                    affectedSquaresLeftForward.Add(positionLeftForward);
                    var move = new PossibleMove(positionLeftForward, new List<Position>(affectedSquaresLeftForward), 0);
                    result.Add(move);
                }
            }
        }


        {
            var affectedSquaresLeftBackward = new List<Position>();
            var positionLeftBackward = currentPosition;
            while (positionLeftBackward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionLeftBackward = positionLeftBackward.LeftBackward();
                if (positionLeftBackward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionLeftBackward);
                    if (piece is not null)
                    {
                        break;
                    }
                    
                    affectedSquaresLeftBackward.Add(positionLeftBackward);
                    var move = new PossibleMove(positionLeftBackward, new List<Position>(affectedSquaresLeftBackward), 0);
                    result.Add(move);
                }
            }
        }

        {
            var affectedSquaresRightBackward = new List<Position>();
            var positionRightBackward = currentPosition;
            while (positionRightBackward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionRightBackward = positionRightBackward.RightBackward();
                if (positionRightBackward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionRightBackward);
                    if (piece is not null)
                    {
                        break;
                    }

                    affectedSquaresRightBackward.Add(positionRightBackward);
                    var move = new PossibleMove(positionRightBackward, new List<Position>(affectedSquaresRightBackward), 0);
                    result.Add(move);
                }
            }
        }
        
        return result;
    }

    public bool UpgradeRequired(Position currentPosition) => false;
}