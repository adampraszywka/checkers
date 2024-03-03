using System.Collections.ObjectModel;

namespace Domain;

public class Board
{
    private readonly int _boardSize;
    
    private readonly Square[,] _squares;
    private readonly List<Piece> _pieces;
    
    public ReadOnlyDictionary<int, IEnumerable<SquareSnapshot>> Snapshot()
    {
        var tmp = new Dictionary<int, IEnumerable<SquareSnapshot>>();
        
        for (var row = 0; row < _boardSize; row++)
        {
            var rowSquares = new List<SquareSnapshot>();
            for (var column = 0; column < _boardSize; column++)
            {
                rowSquares.Add(_squares[row, column].Snapshot);
            }

            tmp[row + 1] = rowSquares;
        }

        return tmp.AsReadOnly();
    }
    
    public Board(Configuration configuration)
    {
        _boardSize = configuration.BoardSize;
        _squares = new Square[_boardSize, _boardSize];
        _pieces = new List<Piece>();
        
        for (var row = 0; row < _boardSize; row++)
        {
            for (var column = 0; column < _boardSize; column++)
            {
                var name = $"{MapColumn(column)}{row + 1}";
                _squares[row, column] = new Square(name);
            }
        }

        foreach (var create in configuration.PiecesPositions)
        {
            var id = Guid.NewGuid().ToString();
            var (piece, position) = create(id);

            if (position.Column > _boardSize || position.Row > _boardSize)
            {
                //TODO: Catch an error and throw it in exception?
                throw new NotImplementedException();
            }
            
            var square = _squares[position.Row, position.Column];
            var result = square.Move(piece);
            if (result.IsFailed)
            {
                //TODO: Catch an error and throw it in exception?
                throw new NotImplementedException();
            }
            
            _pieces.Add(piece);
        }
    }

    private static char MapColumn(int rowNumber)
    {
        return rowNumber switch
        {
            0 => 'A',
            1 => 'B',
            2 => 'C',
            3 => 'D',
            4 => 'E',
            5 => 'F',
            6 => 'G',
            7 => 'H',
            _ => throw new InvalidOperationException()
        };
    }
}

