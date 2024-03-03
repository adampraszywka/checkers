using Domain;
using Domain.Errors;

namespace DomainTests;

public class SquareTests
{
    private class DummyPiece(string id, Color color) : Piece
    {
        public string Id => id;
        public Color Color => color;
        public string Type => "dummy";
    }
    
    [Test]
    public void EmptySquare()
    {
        var square = new Square("A1");
        
        Assert.IsFalse(square.IsOccupied);
    }
    
    [Test]
    public void MovePiece()
    {
        var square = new Square("A1");
        var piece = new DummyPiece("1", Color.Black);
        
        square.Move(piece);
        
        Assert.IsTrue(square.IsOccupied);
    }
    
    [Test]
    public void MovePieceToOccupiedSquare()
    {
        var square = new Square("A1");
        var piece1 = new DummyPiece("1", Color.Black);
        var piece2 = new DummyPiece("2", Color.Black);
        
        var result1 = square.Move(piece1);
        var result2 = square.Move(piece2);
        
        Assert.IsTrue(square.IsOccupied);
        Assert.IsTrue(result1.IsSuccess);
        Assert.IsTrue(result2.HasError<SquareOccupied>());
    }
    
    [Test]
    public void RemovePieceFromEmptySquare()
    {
        var square = new Square("A1");

        var result = square.RemovePiece();

        Assert.IsTrue(result.HasError<SquareEmpty>());
    }
    
    [Test]
    public void RemovePiece()
    {
        var square = new Square("A1");
        var piece = new DummyPiece("1", Color.Black);
        
        var moveResult = square.Move(piece);
        Assert.IsTrue(moveResult.IsSuccess);

        var removeResult = square.RemovePiece();
            
        Assert.IsTrue(removeResult.IsSuccess);
        Assert.IsFalse(square.IsOccupied);
    }
}