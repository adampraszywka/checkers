using Domain;

namespace DomainTests;

public class PositionTests
{
    [Test]
    public void RightForward()
    {
        var position = new Position(Position.R5, Position.C);
        var newPosition = position.RightForward();
        
        Assert.That(newPosition, Is.EqualTo(new Position(Position.R6, Position.D)));
    }

    [Test]
    public void RightBackward()
    {
        var position = new Position(Position.R5, Position.C);
        var newPosition = position.RightBackward();
        
        Assert.That(newPosition, Is.EqualTo(new Position(Position.R4, Position.D)));
    }

    [Test]
    public void LeftForward()
    {
        var position = new Position(Position.R5, Position.C);
        var newPosition = position.LeftForward();
        
        Assert.That(newPosition, Is.EqualTo(new Position(Position.R6, Position.B)));
    }

    [Test]
    public void LeftBackward()
    {
        var position = new Position(Position.R5, Position.C);
        var newPosition = position.LeftBackward();
        
        Assert.That(newPosition, Is.EqualTo(new Position(Position.R4, Position.B)));
    }

    [Test]
    public void PositionEqualsByValue()
    {
        var pos1 = new Position(Position.R1, Position.B);
        var pos2 = new Position(Position.R1, Position.B);
        
        Assert.That(pos1, Is.EqualTo(pos2));
    }
}
