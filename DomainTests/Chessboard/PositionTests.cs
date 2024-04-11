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
    public void PositionNameMapping(int row, int column, string expectedId)
    {
        var position = new Position(row, column);

        Assert.That(position.Name, Is.EqualTo(expectedId));
        Assert.That(position.Row, Is.EqualTo(row));
        Assert.That(position.Column, Is.EqualTo(column));
    }
}