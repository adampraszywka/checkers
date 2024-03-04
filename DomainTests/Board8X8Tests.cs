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
        var expected = new Dictionary<int, TestSquare[]>
        {
            { 8, [Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan]},
            { 7, [BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty]},
            { 6, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 5, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 4, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 3, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 2, [Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan]},
            { 1, [WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty]}
        };

        Assert.That(snapshot, Is.EquivalentTo(expected));
    }
    
    [Test]
    public void FirstMove()
    {
        var configuration = new Checkers8X8();
        var board = new Board(configuration);

        
        var snapshot = board.Snapshot.ToTestSquares(); 
        var expected = new Dictionary<int, TestSquare[]>
        {
            { 8, [Empty, 	BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan]},
            { 7, [BlackMan, Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty, 		BlackMan, 	Empty]},
            { 6, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 5, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 4, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 3, [Empty, 	Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty, 		Empty]},
            { 2, [Empty, 	WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan]},
            { 1, [WhiteMan, Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty, 		WhiteMan, 	Empty]}
        };

        Assert.That(snapshot, Is.EquivalentTo(expected));
    }
}