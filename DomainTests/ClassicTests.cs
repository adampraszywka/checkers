using Domain;
using Domain.Configurations.Classic;
using Domain.Errors.Board;
using Domain.Pieces;
using Domain.Pieces.Classic;
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
    [TestCase(4, 0, -100, -100)]
    [TestCase(4, 0, -1, -1)]
    [TestCase(4, 0, 0, 8)]
    [TestCase(4, 0, 0, 9)]
    [TestCase(4, 0, 8, 0)]
    [TestCase(4, 0, 9, 0)]
    [TestCase(4, 0, 100, 100)]
    [TestCase(-1, -1, 0, 0)]
    [TestCase(100, 100, 0, 0)]
    [TestCase(9, 9,     0, 0)]
    [TestCase(8, 7, 0, 0)]
    [TestCase(7, 8, 0, 0)]
    public void MoveOutOfBoard(int sourceRow, int sourceColumn, int targetRow, int targetColumn)
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(new Position(sourceRow, sourceColumn), new Position(targetRow, targetColumn));
        
        Assert.That(result.HasError<PositionOutOfBoard>());
    }

    [Test]
    public void SquareEmpty()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(Position.B4, Position.C5);
        
        Assert.That(result.HasError<EmptySquare>());
    }

    [Test]
    public void MoveNotAllowed()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(Position.A1, Position.H8);
        
        Assert.That(result.HasError<MoveNotAllowed>());
    }
    
    [Test]
    public void FirstMove()
    {
        var configuration = ClassicConfiguration.NewBoard();
        var board = new Board(configuration);

        var result = board.Move(Position.A3, Position.B4);
        
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

    [Test]
    public void WhiteUpgradesToKingOnceOppositeSideOfBoardReachedByMove()
    {
        var white = new Man("W", Color.White);
        
        var configuration = ClassicConfiguration.FromSnapshot(new []{((Piece) white, Position.E7)});
        var board = new Board(configuration);

        var result = board.Move(Position.E7, Position.D8);
        
        Assert.That(result.IsSuccess);
        
        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            { Empty, 	Empty, 	    Empty, 		WhiteKing,  Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 	    Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty,    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty}
        };
        
        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
    
    [Test]
    public void WhiteUpgradesToKingOnceOppositeSideOfBoardReachedByCapture()
    {
        var white = new Man("A1", Color.White);
        var black = new Man("A2", Color.Black);
        
        var configuration = ClassicConfiguration.FromSnapshot(new [] {((Piece) black, Position.E7), ((Piece) white, Position.F6)});
        var board = new Board(configuration);

        var result = board.Move(Position.F6, Position.D8);
        
        Assert.That(result.IsSuccess);
        
        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            { Empty, 	Empty, 	    Empty, 		WhiteKing,  Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 	    Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty,    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty}
        };
        
        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
    
    [Test]
    public void BlackUpgradesToKingOnceOppositeSideOfBoardReachedByMove()
    {
        var black = new Man("W", Color.Black);
        
        var configuration = ClassicConfiguration.FromSnapshot(new []{((Piece) black, Position.D2)});
        var board = new Board(configuration);

        var result = board.Move(Position.D2, Position.C1);
        
        Assert.That(result.IsSuccess);
        
        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            { Empty, 	Empty, 	    Empty, 		Empty,      Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 	    Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty,    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 		BlackKing,  Empty, 		Empty, 	    Empty, 		Empty, 	    Empty}
        };
        
        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
    
    [Test]
    public void BlackUpgradesToKingOnceOppositeSideOfBoardReachedByCapture()
    {
        var white = new Man("A1", Color.White);
        var black = new Man("A2", Color.Black);
        
        var configuration = ClassicConfiguration.FromSnapshot(new [] {((Piece) black, Position.C3), ((Piece) white, Position.D2)});
        var board = new Board(configuration);

        var result = board.Move(Position.C3, Position.E1);
        
        Assert.That(result.IsSuccess);
        
        var snapshot = board.Snapshot.ToTestSquares();
        var expected = new[,]
        {
            { Empty, 	Empty, 	    Empty, 		Empty,      Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 	    Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty,    Empty, 		Empty, 	    Empty, 		Empty,	    Empty, 		Empty, 	    Empty},
            { Empty, 	Empty, 	    Empty, 		Empty, 	    Empty, 		Empty, 	    Empty, 		Empty},
            { Empty,    Empty, 		Empty, 	    Empty, 		BlackKing,  Empty, 		Empty, 	    Empty}
        };
        
        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
}