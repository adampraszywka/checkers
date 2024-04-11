using Domain.Chessboard;

namespace DomainTests.Chessboard;

public class PositionTests
{
    public static IEnumerable<object[]> FactoryMethodsTestCases
    {
        get
        {
            yield return [Position.A1, 0, 0];
            yield return [Position.C1, 0, 2];
            yield return [Position.E1, 0, 4];
            yield return [Position.G1, 0, 6];
            yield return [Position.B2, 1, 1];
            yield return [Position.D2, 1, 3];
            yield return [Position.F2, 1, 5];
            yield return [Position.H2, 1, 7];
            yield return [Position.A3, 2, 0];
            yield return [Position.C3, 2, 2];
            yield return [Position.E3, 2, 4];
            yield return [Position.G3, 2, 6];
            yield return [Position.B4, 3, 1];
            yield return [Position.D4, 3, 3];
            yield return [Position.F4, 3, 5];
            yield return [Position.H4, 3, 7];
            yield return [Position.A5, 4, 0];
            yield return [Position.C5, 4, 2];
            yield return [Position.E5, 4, 4];
            yield return [Position.G5, 4, 6];
            yield return [Position.B6, 5, 1];
            yield return [Position.D6, 5, 3];
            yield return [Position.F6, 5, 5];
            yield return [Position.H6, 5, 7];
            yield return [Position.A7, 6, 0];
            yield return [Position.C7, 6, 2];
            yield return [Position.E7, 6, 4];
            yield return [Position.G7, 6, 6];
            yield return [Position.B8, 7, 1];
            yield return [Position.D8, 7, 3];
            yield return [Position.F8, 7, 5];
            yield return [Position.H8, 7, 7];
        }
    }

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

    [Test]
    [TestCaseSource(nameof(FactoryMethodsTestCases))]
    public void FactoryMethods(Position position, int row, int column)
    {
        Assert.That(position.Row, Is.EqualTo(row));
        Assert.That(position.Column, Is.EqualTo(column));
    }
}