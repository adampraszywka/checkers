using Domain;
using Extension;

namespace WebApi.Dto;

public record BoardDto
{
    public int Columns { get; }
    public int Rows { get; }
    public IEnumerable<IEnumerable<SquareSnapshot>> Squares { get; }
    
    public BoardDto(BoardSnapshot snapshot)
    {
        Columns = snapshot.BoardSize.Columns;
        Rows = snapshot.BoardSize.Rows;
        Squares = snapshot.Squares.ReversedRowsListOfLists();
    }
}