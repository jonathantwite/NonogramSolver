namespace NonogramSolver.Tests;

public class RowTests
{
    public static IEnumerable<object[]> ToStringGivesCorrectOutputData => new List<object[]> {
        new object[] { new Row(3, []), "| | | |" },
        new object[] { new Row(2, []), "| | |" },
        };

    [Theory]
    [MemberData(nameof(ToStringGivesCorrectOutputData))]
    public void ToStringGivesCorrectOutput(Row row, string expected)
    {
        // Arrange

        // Act
        var actual = row.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(5, new int[] { 2, 3 })]
    [InlineData(5, new int[] { 3, 3 })]
    [InlineData(5, new int[] { 6 })]
    public void ConstructorThrowIfClueIsTooBig(int size, int[] clues)
    {
        // Act
        Assert.Throws<ArgumentException>(() =>
        {
            new Row(size, clues);
        });
    }

    [Theory]
    [InlineData(5, new int[] { 2, 2 })]
    [InlineData(5, new int[] { 1, 2 })]
    [InlineData(5, new int[] { 5 })]
    [InlineData(5, new int[] { 0 })]
    public void ConstructorDoesNotThrowIfClueIsOkSize(int size, int[] clues)
    {
        // Act
        var row = new Row(size, clues);
    }
}
