using Domain.Chessboard.Pieces;
using Domain.Chessboard.Pieces.Classic;

namespace DomainTests.Chessboard.Pieces.Classic;

public class KingTests
{
    [Test]
    [TestCase(Color.Black)]
    [TestCase(Color.White)]
    public void NewKing(Color color)
    {
        var king = new King("ID", color);

        Assert.That(king.Id, Is.EqualTo("ID"));
        Assert.That(king.Color, Is.EqualTo(color));
    }
}