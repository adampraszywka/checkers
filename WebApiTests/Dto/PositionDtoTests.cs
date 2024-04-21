using Contracts.Dto;
using WebApi.Dto.Response;
using WebApi.Extensions;

namespace WebApiTests.Dto;

public class PositionDtoTests
{
    [Test]
    public void ToPosition()
    {
        var dto = new PositionDto(1, 2);

        var position = dto.ToPosition();
        
        Assert.That(position.Row, Is.EqualTo(1));
        Assert.That(position.Column, Is.EqualTo(2));
    }
}