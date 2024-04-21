using FluentResults;
using WebApi.Results;

namespace WebApiTests.Results;

public class ActionResultTests
{
    [Test]
    public void Success()
    {
        var result = ActionResult<string>.Success("value");
        
        Assert.That(result.Value, Is.EqualTo("value"));
        Assert.That(result.IsSuccessful, Is.True);
        Assert.Throws<InvalidOperationException>(() => _ = result.ErrorMessage);
    }
    
    [Test]
    public void Failed()
    {
        var result = ActionResult<string>.Failed("error");
        
        Assert.That(result.ErrorMessage, Is.EqualTo("error"));
        Assert.That(result.IsSuccessful, Is.False);
        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }

    [Test]
    public void FailedFromSingleError()
    {
        var error = new Error("error");
        var result = ActionResult<string>.FromErrors(new[] {error});
        
        Assert.That(result.ErrorMessage, Is.EqualTo("error"));
        Assert.That(result.IsSuccessful, Is.False);
        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }
    
    [Test]
    public void FailedFromErrors()
    {
        Error[] errors = [new Error("error1"), new Error("error2")];
        var result = ActionResult<string>.FromErrors(errors);
        
        Assert.That(result.ErrorMessage, Is.EqualTo("error1, error2"));
        Assert.That(result.IsSuccessful, Is.False);
        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }
}