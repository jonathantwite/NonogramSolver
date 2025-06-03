namespace NonogramSolver.Tests;

public class RowUtilitiesTests
{
    private static Row CreateAllPossibilities0Data => new(4, [0]);
    private static IEnumerable<bool[]> CreateAllPossibilities0Expected => [[false, false, false, false]];

    [Fact]
    public void CreateAllPossibilitiesBruteForceReturnsCorrectForNoClues()
    {
        // Act
        var actual = RowUtilities.CreateAllPossibilitiesBruteForce(CreateAllPossibilities0Data.Size, CreateAllPossibilities0Data.Clues);

        // Assert
        Assert.Equivalent(CreateAllPossibilities0Expected, actual, strict: true);
    }

    [Fact]
    public void CreateAllPossibilitiesByGapReturnsCorrectForNoClues()
    {
        // Act
        var actual = RowUtilities.CreateAllPossibilitiesByGap(CreateAllPossibilities0Data.Size, CreateAllPossibilities0Data.Clues);

        // Assert
        Assert.Equivalent(CreateAllPossibilities0Expected, actual, strict: true);
    }

    private static Row CreateAllPossibilities1Data => new(4, [2]);
    private static IEnumerable<bool[]> CreateAllPossibilities1Expected => [
            [true, true, false, false],
            [false, true, true, false],
            [false, false, true, true]];

    [Fact]
    public void CreateAllPossibilitiesBruteForceReturnsCorrectForOneClue()
    {
        // Act
        var actual = RowUtilities.CreateAllPossibilitiesBruteForce(CreateAllPossibilities1Data.Size, CreateAllPossibilities1Data.Clues);

        // Assert
        Assert.Equivalent(CreateAllPossibilities1Expected, actual, strict: true);
    }

    [Fact]
    public void CreateAllPossibilitiesByGapReturnsCorrectForOneClue()
    {
        // Act
        var actual = RowUtilities.CreateAllPossibilitiesByGap(CreateAllPossibilities1Data.Size, CreateAllPossibilities1Data.Clues);

        // Assert
        Assert.Equivalent(CreateAllPossibilities1Expected, actual, strict: true);
    }


    private static Row CreateAllPossibilities2Data => new (7, [1, 3]);
    private static IEnumerable<bool[]> CreateAllPossibilities2Expected => [
            [ true, false,  true,  true,  true, false, false],
            [ true, false, false,  true,  true,  true, false],
            [ true, false, false, false,  true,  true,  true],
            [false,  true, false,  true,  true,  true, false],
            [false,  true, false, false,  true,  true,  true],
            [false, false,  true, false,  true,  true,  true]];


    [Fact]
    public void CreateAllPossibilitiesBruteForceReturnsCorrectForTwoClues()
    {
        // Act
        var actual = RowUtilities.CreateAllPossibilitiesBruteForce(CreateAllPossibilities2Data.Size, CreateAllPossibilities2Data.Clues);

        // Assert
        Assert.Equivalent(CreateAllPossibilities2Expected, actual, strict: true);
    }

    [Fact]
    public void CreateAllPossibilitiesByGapReturnsCorrectForTwoClues()
    {
        // Act
        var actual = RowUtilities.CreateAllPossibilitiesByGap(CreateAllPossibilities2Data.Size, CreateAllPossibilities2Data.Clues);

        // Assert
        Assert.Equivalent(CreateAllPossibilities2Expected, actual, strict: true);
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
