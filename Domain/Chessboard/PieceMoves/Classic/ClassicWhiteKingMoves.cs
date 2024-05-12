using Domain.Shared;

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
            var previousWasOccupiedByOpponent = false;
            var capturedPieces = 0;
            while (positionRightForward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionRightForward = positionRightForward.RightForward();
                if (positionRightForward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionRightForward);
                    
                    // Two pieces in row, color doesn't matter
                    if (piece is not null && previousWasOccupiedByOpponent)
                    {
                        break;
                    }
                    
                    if (piece is null && previousWasOccupiedByOpponent)
                    {
                        capturedPieces++;
                        previousWasOccupiedByOpponent = false;
                    }
                    
                    if (piece is not null && piece.Color == Color.Black)
                    {
                        previousWasOccupiedByOpponent = true;
                        affectedSquaresRightForward.Add(positionRightForward);
                        continue;
                    }

                    if (piece is not null && piece.Color == Color.White)
                    {
                        break;
                    }

                    affectedSquaresRightForward.Add(positionRightForward);
                    var move = new PossibleMove(positionRightForward, new List<Position>(affectedSquaresRightForward), capturedPieces);
                    result.Add(move);
                }
            }
        }

        {
            var affectedSquaresLeftForward = new List<Position>();
            var positionLeftForward = currentPosition;
            var previousWasOccupiedByOpponent = false;
            var capturedPieces = 0;
            
            while (positionLeftForward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionLeftForward = positionLeftForward.LeftForward();
                if (positionLeftForward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionLeftForward);
                    
                    // Two pieces in row, color doesn't matter
                    if (piece is not null && previousWasOccupiedByOpponent)
                    {
                        break;
                    }
                    
                    if (piece is null && previousWasOccupiedByOpponent)
                    {
                        capturedPieces++;
                        previousWasOccupiedByOpponent = false;
                    }
                    
                    if (piece is not null && piece.Color == Color.Black)
                    {
                        previousWasOccupiedByOpponent = true;
                        affectedSquaresLeftForward.Add(positionLeftForward);
                        continue;
                    }

                    if (piece is not null && piece.Color == Color.White)
                    {
                        break;
                    }

                    affectedSquaresLeftForward.Add(positionLeftForward);
                    var move = new PossibleMove(positionLeftForward, new List<Position>(affectedSquaresLeftForward), capturedPieces);
                    result.Add(move);
                }
            }
        }


        {
            var affectedSquaresLeftBackward = new List<Position>();
            var positionLeftBackward = currentPosition;
            var previousWasOccupiedByOpponent = false;
            var capturedPieces = 0;
            
            while (positionLeftBackward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionLeftBackward = positionLeftBackward.LeftBackward();
                if (positionLeftBackward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionLeftBackward);
                    
                    // Two pieces in row, color doesn't matter
                    if (piece is not null && previousWasOccupiedByOpponent)
                    {
                        break;
                    }
                    
                    if (piece is null && previousWasOccupiedByOpponent)
                    {
                        capturedPieces++;
                        previousWasOccupiedByOpponent = false;
                    }
                    
                    if (piece is not null && piece.Color == Color.Black)
                    {
                        previousWasOccupiedByOpponent = true;
                        affectedSquaresLeftBackward.Add(positionLeftBackward);
                        continue;
                    }

                    if (piece is not null && piece.Color == Color.White)
                    {
                        break;
                    }
                    
                    affectedSquaresLeftBackward.Add(positionLeftBackward);
                    var move = new PossibleMove(positionLeftBackward, new List<Position>(affectedSquaresLeftBackward), capturedPieces);
                    result.Add(move);
                }
            }
        }

        {
            var affectedSquaresRightBackward = new List<Position>();
            var positionRightBackward = currentPosition;
            var previousWasOccupiedByOpponent = false;
            var capturedPieces = 0;
            
            while (positionRightBackward.IsWithinBoard(boardSnapshot.BoardSize))
            {
                positionRightBackward = positionRightBackward.RightBackward();
                if (positionRightBackward.IsWithinBoard(boardSnapshot.BoardSize))
                {
                    var piece = boardSnapshot.At(positionRightBackward);
                    
                    // Two pieces in row, color doesn't matter
                    if (piece is not null && previousWasOccupiedByOpponent)
                    {
                        break;
                    }
                    
                    if (piece is null && previousWasOccupiedByOpponent)
                    {
                        capturedPieces++;
                        previousWasOccupiedByOpponent = false;
                    }
                    
                    if (piece is not null && piece.Color == Color.Black)
                    {
                        previousWasOccupiedByOpponent = true;
                        affectedSquaresRightBackward.Add(positionRightBackward);
                        continue;
                    }

                    if (piece is not null && piece.Color == Color.White)
                    {
                        break;
                    }

                    affectedSquaresRightBackward.Add(positionRightBackward);
                    var move = new PossibleMove(positionRightBackward, new List<Position>(affectedSquaresRightBackward), capturedPieces);
                    result.Add(move);
                }
            }
        }

        if (!result.Any())
        {
            return result;
        }
        
        var maxCaptured = result.Max(x => x.CapturedPieces);
        return result.Where(x => x.CapturedPieces == maxCaptured);
    }

    public bool UpgradeRequired(Position currentPosition) => false;
}