namespace Domain;

public class Board
{
    private readonly int _boardSize;
    
    private readonly Square[,] _squares;
    private readonly List<Piece> _pieces;

    public BoardSnapshot Snapshot => GenerateSnapshot();
    
    public Board(Configuration configuration)
    {
        _boardSize = configuration.BoardSize;
        _squares = new Square[_boardSize, _boardSize];
        _pieces = new List<Piece>();
        
        for (var row = 0; row < _boardSize; row++)
        {
            for (var column = 0; column < _boardSize; column++)
            {
                _squares[row, column] = Square.FromCoordinates(row, column);
            }
        }

        foreach (var (piece, position) in configuration.PiecesPositions)
        {
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
    
    private BoardSnapshot GenerateSnapshot()
    {
        var tmp = new Dictionary<int, IEnumerable<SquareSnapshot>>();
        
        for (var row = 0; row < _boardSize; row++)
        {
            var rowSquares = new List<SquareSnapshot>();
            for (var column = 0; column < _boardSize; column++)
            {
                rowSquares.Add(_squares[row, column].Snapshot());
            }

            tmp[row + 1] = rowSquares;
        }

        return new(tmp.AsReadOnly());
    }
}

