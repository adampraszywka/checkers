using Domain.Chessboard;
using Domain.Chessboard.GameStates;
using Domain.Shared;
using Extension;

namespace WebApi.Dto.Response;

public record BoardDto
{
    public BoardDto(Board board)
    {
        Id = board.Id;
        Columns = board.Snapshot.BoardSize.Columns;
        Rows = board.Snapshot.BoardSize.Rows;
        Squares = board.Snapshot.Squares.ReversedRowsListOfLists();
        MoveLog = board.Snapshot.GameState.Log;
        CurrentPlayer = board.Snapshot.GameState.CurrentPlayer;
    }

    public string Id { get; }
    public int Columns { get; }
    public int Rows { get; }
    public IEnumerable<IEnumerable<SquareSnapshot>> Squares { get; }
    public IEnumerable<Move> MoveLog { get; }
    public Color CurrentPlayer { get; }
}