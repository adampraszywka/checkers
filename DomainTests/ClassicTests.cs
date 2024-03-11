using Domain;
using Domain.Configurations.Classic;
using Domain.Errors.Board;
using DomainTests.Extensions;
using static DomainTests.Extensions.TestSquare;

namespace DomainTests;

public class ClassicTests
{
    [Test]
    public void NewBoard()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var snapshot = board.Snapshot.ToTestSquares(); 
        var expected = new[,]
        {
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty},
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { WhiteMan,	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty},
            { Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan},
            { WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }

    [Test]
    [TestCase(-100, -100)]
    [TestCase(-1, -1)]
    [TestCase(0, 8)]
    [TestCase(0, 9)]
    [TestCase(8, 0)]
    [TestCase(9, 0)]
    [TestCase(100, 100)]
    public void MoveOutOfBoard(int row, int column)
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move("A2", new Position(row, column));
        
        Assert.That(result.HasError<PositionOutOfBoard>());
    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("test")]
    [TestCase("doesNotExist")]
    public void PieceNotFound(string pieceId)
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move("A2", new Position(Position.R1, Position.A));
        
        Assert.That(result.HasError<PieceNotFound>());
    }
    
    [Test]
    public void FirstMove()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move("A3", new Position(Position.R4, Position.B));
        
        Assert.That(result.IsSuccess);
        
        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty},
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan,	Empty, 		BlackMan},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	WhiteMan, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty,    Empty, 		WhiteMan, 	Empty, 		WhiteMan,	Empty, 		WhiteMan, 	Empty},
            { Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan},
            { WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty}
        };
        
        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
}