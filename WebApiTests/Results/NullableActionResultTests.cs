using FluentResults;
using WebApi.Results;

namespace WebApiTests.Results;

public class NullableActionResultTests
{
    [Test]
    public void Success()
    {
        var result = NullableActionResult<string>.Success("Success!");
        
        Assert.That(result.IsSuccessful, Is.True);
        Assert.That(result.Value, Is.EqualTo("Success!"));
        Assert.That(result.ErrorMessage, Is.Null);
    }

    [Test]
    public void Failed()
    {
        var result = NullableActionResult<string>.Failed("Failed!", "code");
        
        Assert.That(result.IsSuccessful, Is.False);
        Assert.That(result.Value, Is.Null);
        Assert.That(result.ErrorMessage, Is.EqualTo("Failed!"));
        Assert.That(result.ErrorCode, Is.EqualTo("code"));
    }
    
    [Test]
    public void FailedFromErrors()
    {
        var error = new Error("Failed!");
        var result = NullableActionResult<string>.FromErrors(new[] {error}, "code");
        
        Assert.That(result.IsSuccessful, Is.False);
        Assert.That(result.Value, Is.Null);
        Assert.That(result.ErrorMessage, Is.EqualTo("Failed!"));
        Assert.That(result.ErrorCode, Is.EqualTo("code"));
    }
}