using Domain;
using Domain.Errors;
using Domain.Pieces;

namespace DomainTests;

public class SquareTests
{
    [Test]
    [TestCase(0, 0, "A1")]
    [TestCase(0, 1, "B1")]
    [TestCase(0, 2, "C1")]
    [TestCase(0, 3, "D1")]
    [TestCase(0, 4, "E1")]
    [TestCase(0, 5, "F1")]
    [TestCase(0, 6, "G1")]
    [TestCase(0, 7, "H1")]
    [TestCase(1, 0, "A2")]
    [TestCase(1, 1, "B2")]
    [TestCase(1, 2, "C2")]
    [TestCase(1, 3, "D2")]
    [TestCase(1, 4, "E2")]
    [TestCase(1, 5, "F2")]
    [TestCase(1, 6, "G2")]
    [TestCase(1, 7, "H2")]
    [TestCase(2, 0, "A3")]
    [TestCase(2, 1, "B3")]
    [TestCase(2, 2, "C3")]
    [TestCase(2, 3, "D3")]
    [TestCase(2, 4, "E3")]
    [TestCase(2, 5, "F3")]
    [TestCase(2, 6, "G3")]
    [TestCase(2, 7, "H3")]
    [TestCase(3, 0, "A4")]
    [TestCase(3, 1, "B4")]
    [TestCase(3, 2, "C4")]
    [TestCase(3, 3, "D4")]
    [TestCase(3, 4, "E4")]
    [TestCase(3, 5, "F4")]
    [TestCase(3, 6, "G4")]
    [TestCase(3, 7, "H4")]
    [TestCase(4, 0, "A5")]
    [TestCase(4, 1, "B5")]
    [TestCase(4, 2, "C5")]
    [TestCase(4, 3, "D5")]
    [TestCase(4, 4, "E5")]
    [TestCase(4, 5, "F5")]
    [TestCase(4, 6, "G5")]
    [TestCase(4, 7, "H5")]
    [TestCase(5, 0, "A6")]
    [TestCase(5, 1, "B6")]
    [TestCase(5, 2, "C6")]
    [TestCase(5, 3, "D6")]
    [TestCase(5, 4, "E6")]
    [TestCase(5, 5, "F6")]
    [TestCase(5, 6, "G6")]
    [TestCase(5, 7, "H6")]
    [TestCase(6, 0, "A7")]
    [TestCase(6, 1, "B7")]
    [TestCase(6, 2, "C7")]
    [TestCase(6, 3, "D7")]
    [TestCase(6, 4, "E7")]
    [TestCase(6, 5, "F7")]
    [TestCase(6, 6, "G7")]
    [TestCase(6, 7, "H7")]
    [TestCase(7, 0, "A8")]
    [TestCase(7, 1, "B8")]
    [TestCase(7, 2, "C8")]
    [TestCase(7, 3, "D8")]
    [TestCase(7, 4, "E8")]
    [TestCase(7, 5, "F8")]
    [TestCase(7, 6, "G8")]
    [TestCase(7, 7, "H8")]
    [TestCase(0, 24, "Y1")]
    [TestCase(0, 25, "Z1")]
    public void FromCoordinatesMapping(int row, int column, string expectedId)
    {
        var square = Square.FromCoordinates(row, column);
        
        Assert.That(square.Id, Is.EqualTo(expectedId));
        Assert.That(square.Column, Is.EqualTo(column));
        Assert.That(square.Row, Is.EqualTo(row));
        Assert.That(square.IsOccupied, Is.False);
    }

    [Test]
    [TestCase(0, 26)]
    [TestCase(0, 27)]
    public void FromCoordinatesMappingOutOfRange(int row, int column)
    {
        Assert.Throws<ArgumentException>(() => Square.FromCoordinates(row, column));
    }
    
    [Test]
    public void EmptySquare()
    {
        var square = Square.FromCoordinates(0, 0);
        
        Assert.IsFalse(square.IsOccupied);
    }
    
    [Test]
    public void MovePiece()
    {
        var square = Square.FromCoordinates(0, 0);
        var piece = new Man("1", Color.Black);
        
        square.Move(piece);
        
        Assert.That(square.IsOccupied, Is.True);
    }
    
    [Test]
    public void MovePieceToOccupiedSquare()
    {
        var square = Square.FromCoordinates(0, 0);
        var piece1 = new Man("1", Color.Black);
        var piece2 = new Man("2", Color.Black);
        
        var result1 = square.Move(piece1);
        var result2 = square.Move(piece2);
        
        Assert.That(square.IsOccupied, Is.True);
        Assert.That(result1.IsSuccess, Is.True);
        Assert.That(result2.HasError<SquareOccupied>(), Is.True);
    }
    
    [Test]
    public void RemovePieceFromEmptySquare()
    {
        var square = Square.FromCoordinates(0, 0);

        var result = square.RemovePiece();

        Assert.That(result.HasError<SquareEmpty>(), Is.True);
    }
    
    [Test]
    public void RemovePiece()
    {
        var square = Square.FromCoordinates(0, 0);
        var piece = new Man("1", Color.Black);
        
        var moveResult = square.Move(piece);
        Assert.That(moveResult.IsSuccess, Is.True);

        var removeResult = square.RemovePiece();
            
        Assert.That(removeResult.IsSuccess, Is.True);
        Assert.That(square.IsOccupied, Is.False);
    }
}