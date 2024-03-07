using Extension;

namespace ExtensionTests;

public class RectangularArrayExtensionsTests
{
    [Test]
    public void Flatten()
    {
        var input = new[,] { {"A", "B", "C"}, {"D", "E", "F"}, {"G", "H", "I"}};
        var expected = new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I"};
        
        Assert.That(input.Flatten(), Is.EquivalentTo(expected));
    }

    [Test]
    public void Transform()
    {
        var input = new[,] {{"a", "b"}, {"c", "d"}};
        var expectedOutput = new[,] {{"A", "B"}, {"C", "D"}};

        var result = input.Transform(x => x.ToUpper());
        
        Assert.That(result.Flatten(), Is.EquivalentTo(expectedOutput.Flatten()));
    }
}