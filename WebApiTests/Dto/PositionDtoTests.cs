using WebApi.Dto;

namespace WebApiTests.Dto;

public class PositionDtoTests
{
    [Test]
    public void ToPosition()
    {
        var dto = new PositionDto(1, 2);

        var position = dto.Position;
        
        Assert.That(position.Row, Is.EqualTo(1));
        Assert.That(position.Column, Is.EqualTo(2));
    }
}