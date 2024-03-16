using Domain;
using Extension;

namespace WebApi.Dto;

public class BoardDto
{
    public int Columns { get; }
    public int Rows { get; }
    public IEnumerable<SquareSnapshot> Squares { get; }
    
    public BoardDto(BoardSnapshot snapshot)
    {
        Columns = snapshot.Columns;
        Rows = snapshot.Rows;
        Squares = snapshot.Squares.ReverseRows().Flatten();
    }
}