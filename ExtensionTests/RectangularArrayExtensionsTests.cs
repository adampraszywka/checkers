using Extension;

namespace ExtensionTests;

public class RectangularArrayExtensionsTests
{
    public static object[] DimensionsCases = [ 
        new object[] {new[,] { {"A"}}, 1, 1},
        new object[] {new[,] { {"A", "B"}, {"D", "E"}}, 2, 2},
        new object[] {new[,] { {"A", "B", "C"}, {"D", "E", "F"}}, 3, 2},
    ];
    
    [Test]
    [TestCaseSource(nameof(DimensionsCases))]
    public void Rows(object[,] input, int expectedRows, int expectedColumns)
    {
        Assert.That(input.Rows(), Is.EqualTo(expectedRows));
        Assert.That(input.Columns(), Is.EqualTo(expectedColumns));
    }
    
    [Test]
    public void Columns()
    {
        var input = new[,] { {"A", "B", "C"}, {"D", "E", "F"}};
        
        Assert.That(input.Rows(), Is.EqualTo(3));
    }
    
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

    public static object[] ReverseRowsCases = [ 
        new object[] {new[,] {{1, 2}, {3, 4}}, new[,] { {3, 4}, {1, 2}}},
        new object[] {new[,] {{1, 2}}, new[,] {{1, 2}}},
    ];
    
    [Test]
    [TestCaseSource(nameof(ReverseRowsCases))]
    public void ReverseRows(int[,] input, int[,] expectedOutput)
    {
        var result = input.ReverseRows();
        
        Assert.That(result.Flatten(), Is.EquivalentTo(expectedOutput.Flatten()));
    }
}