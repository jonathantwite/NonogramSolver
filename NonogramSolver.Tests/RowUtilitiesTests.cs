namespace NonogramSolver.Tests;

public class RowUtilitiesTests
{
    [Fact]
    public void CreateAllPossibilitiesReturnsCorrectForOneClue()
    {
        // Arrange
        var row = new Row(4, [2]);
        IEnumerable<bool[]> expected = [
            [true, true, false, false],
            [false, true, true, false],
            [false, false, true, true]];

        // Act
        var actual = RowUtilities.CreateAllPossibilities(row.Size, row.Clues);

        // Assert
        Assert.Equivalent(expected, actual, strict: true);
    }



    [Fact]
    public void CreateAllPossibilitiesReturnsCorrectForTwoClues()
    {
        // Arrange
        var row = new Row(7, [1, 3]);
        IEnumerable<bool[]> expected = [
            [ true, false,  true,  true,  true, false, false],
            [ true, false, false,  true,  true,  true, false],
            [ true, false, false, false,  true,  true,  true],
            [false,  true, false,  true,  true,  true, false],
            [false,  true, false, false,  true,  true,  true],
            [false, false,  true, false,  true,  true,  true]];

        // Act
        var actual = RowUtilities.CreateAllPossibilities(row.Size, row.Clues);

        // Assert
        Assert.Equivalent(expected, actual, strict: true);
    }



    [Theory]
    [InlineData(new bool[] { false, false, false }, new int[] {0}, true)]
    [InlineData(new bool[] { false, true, false }, new int[] {0}, false)]
    [InlineData(new bool[] { true, false, false }, new int[] {1}, true)]
    [InlineData(new bool[] { false, true, false }, new int[] {1}, true)]
    [InlineData(new bool[] { false, false, true }, new int[] {1}, true)]
    [InlineData(new bool[] { false, false, false }, new int[] {1}, false)]
    [InlineData(new bool[] { true, true, false }, new int[] {1}, false)]
    [InlineData(new bool[] { false, true, true }, new int[] {1}, false)]
    [InlineData(new bool[] { true, true, false, true, false, false }, new int[] {2, 1}, true)]
    [InlineData(new bool[] { false, true, true, false, true, false }, new int[] {2, 1}, true)]
    [InlineData(new bool[] { false, false, true, true, false, true }, new int[] {2, 1}, true)]
    [InlineData(new bool[] { true, true, true, false, false, false }, new int[] {2, 1}, false)]
    [InlineData(new bool[] { true, true, false, true, true, false }, new int[] {2, 1}, false)]
    [InlineData(new bool[] { true, false, true, true, false, false }, new int[] {2, 1}, false)]
    public void RowFulfillsCluesTests(bool[] row, int[] clues, bool expected)
    {
        var actual = RowUtilities.RowFulfillsClues(row, clues);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetAllDefinitesTestsData => new List<object[]>
    {
        new object[] {
            new bool[][] {
                [true, false, false],
                [true, false, true],
                [true, true, true],
            }, new bool?[] { true, null, null }
        },
        new object[] {
            new bool[][] {
                [true, false, false],
                [true, false, true],
                [true, false, true],
            }, new bool?[] { true, false, null }
        },
        new object[] {
            new bool[][] {
                [true, false, false]
            }, new bool?[] { true, false, false }
        }
    };

    [Theory]
    [MemberData(nameof(GetAllDefinitesTestsData))]
    public void GetAllDefinitesTests(bool[][] allPossibilities, bool?[] expected)
    {
        var actual = RowUtilities.GetAllDefinites(allPossibilities);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OverwriteOverwritesCorrectly()
    {
        // Arrange
        Row row = new(4, []);
        row.Overwrite([null, null, true, true]);
        bool?[] expected = [null, true, false, true];
        
        // Act
        row.Overwrite([null, true, false, null]);
        var actual = row.Cells.Select(c => c.Value);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FilterToPossibilitiesThatFitCorrectlyFilters()
    {
        // Arrange
        IEnumerable<bool[]> possibilities = [
            [true, false, false, false],
            [false, true, false, false],
            [true, true, false, false],
            [false, false, true, false],
            [true, false, true, false],
            [false, true, true, false],
            [true, true, true, false],
            [true, false, false, true],
            [false, true, false, true],
            [true, true, false, true],
            [false, false, true, true],
            [true, false, true, true],
            [false, true, true, true],
            [true, true, true, true]];

        Cell[] currentRow = [
            new Cell { Value = null }, 
            new Cell { Value = true }, 
            new Cell { Value = false }, 
            new Cell { Value = null }];

        List<bool[]> expected = [
            [false, true, false, false],
            [true, true, false, false],
            [false, true, false, true],
            [true, true, false, true]];

        // Act
        var actual = RowUtilities.FilterToPossibilitiesThatFit(possibilities, currentRow).ToList();

        // Assert
        Assert.Equal(expected, actual);
    }
}
