using Contracts.Dto;
using Domain.Chessboard;
using Extension;

namespace WebApi.Extensions;

public static class BoardExtensions
{
    public static BoardDto ToDto(this Board board)
    {
        return new()
        {
            Id = board.Id,
            Columns = board.Snapshot.BoardSize.Columns,
            Rows = board.Snapshot.BoardSize.Rows,
            Squares = board.Snapshot.Squares.Transform(x => x.ToDto()).ReversedRowsListOfLists(),
            MoveLog = board.Snapshot.GameState.Log.ToDto(),
            CurrentPlayer = board.Snapshot.GameState.CurrentPlayer.ToDto(),
            Participants = board.Participants.List.ToDto()
        };
    }
}