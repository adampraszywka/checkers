using Domain;
using Domain.Configurations;
using DomainTests.Extensions;
using static DomainTests.Extensions.TestSquare;

namespace DomainTests;

public class Board8X8Tests
{
    [Test]
    public void NewBoard()
    {
        var configuration = new Checkers8X8();
        var board = new Board(configuration);

        var snapshot = board.Snapshot.ToTestSquares(); 
        var expected = new[,]
        {
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan},
            { WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty}
        };

        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
    
    [Test]
    public void FirstMove()
    {
        var configuration = new Checkers8X8();
        var board = new Board(configuration);
        
        var snapshot = board.Snapshot.ToTestSquares();
            
        var expected = new[,]
        {
            { Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan},
            { BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty},
            { Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan},
            { WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty}
        };
        
        BoardAssert.ReversedRowsEqualTo(expected, snapshot);
    }
}