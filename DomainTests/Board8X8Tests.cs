using Domain;
using Domain.Configurations;

namespace DomainTests;

public class Board8X8Tests
{
    [Test]
    public void NewBoard()
    {
        var configuration = new Checkers8X8();
        var board = new Board(configuration);
        

    }
}