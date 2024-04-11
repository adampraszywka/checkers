using Domain.Chessboard;
using Domain.Chessboard.GameStates;
using Domain.Chessboard.Pieces;
using Extension;

namespace WebApi.Dto;

public record BoardDto
{
    public BoardDto(BoardSnapshot snapshot)
    {
        Columns = snapshot.BoardSize.Columns;
        Rows = snapshot.BoardSize.Rows;
        Squares = snapshot.Squares.ReversedRowsListOfLists();
        MoveLog = snapshot.GameState.Log;
        CurrentPlayer = snapshot.GameState.CurrentPlayer;
    }

    public int Columns { get; }
    public int Rows { get; }
    public IEnumerable<IEnumerable<SquareSnapshot>> Squares { get; }
    public IEnumerable<Move> MoveLog { get; }
    public Color CurrentPlayer { get; }
}