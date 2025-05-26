namespace NonogramSolver.Tests;

public class ColumnTests
{
    [Fact]
    public void FromRowsGivesCorrectValues()
    {
        // Arrange
        Row r1 = new(3, []);
        Row r2 = new(3, []);
        Row r3 = new(3, []);

        r1.Overwrite([true, null, false]);
        r2.Overwrite([null, false, false]);
        r3.Overwrite([null, null, true]);

        Row[] rows = [r1, r2, r3];

        bool?[] expected1 = [true, null, null];
        bool?[] expected2 = [null, false, null];
        bool?[] expected3 = [false, false, true];

        // Act
        var cols = Column.FromRows(rows, [[], [], []]);
        var actual1 = cols[0].Cells.Select(c => c.Value);
        var actual2 = cols[1].Cells.Select(c => c.Value);
        var actual3 = cols[2].Cells.Select(c => c.Value);

        // Assert
        Assert.Equal(expected1, actual1);
        Assert.Equal(expected2, actual2);
        Assert.Equal(expected3, actual3);
    }

    [Fact]
    public void FromRowsCreatesColumnsThatAreRefencesToRowValues()
    {
        // Arrange
        Row r1 = new(3, []);
        Row r2 = new(3, []);
        Row r3 = new(3, []);

        Row[] rows = [r1, r2, r3];
        var cols = Column.FromRows(rows, [[], [], []]);

        bool?[] expected1 = [true, null, null];
        bool?[] expected2 = [null, false, null];
        bool?[] expected3 = [false, false, true];

        // Act
        r1.Overwrite([true, null, false]);
        r2.Overwrite([null, false, false]);
        r3.Overwrite([null, null, true]);
        
        var actual1 = cols[0].Cells.Select(c => c.Value);
        var actual2 = cols[1].Cells.Select(c => c.Value);
        var actual3 = cols[2].Cells.Select(c => c.Value);

        // Assert
        Assert.Equal(expected1, actual1);
        Assert.Equal(expected2, actual2);
        Assert.Equal(expected3, actual3);
    }

    [Fact]
    public void FromRowsSetColumnCluesCorrectly()
    {
        // Arrange
        Row r1 = new(3, []);
        Row r2 = new(3, []);
        Row r3 = new(3, []);
        Row[] rows = [r1, r2, r3];

        int[] expected1 = [1, 3, 2];
        int[] expected2 = [2, 1];
        int[] expected3 = [0];

        // Act
        var cols = Column.FromRows(rows, [[1, 3, 2], [2, 1], [0]]);
        var actual1 = cols[0].Clues;
        var actual2 = cols[1].Clues;
        var actual3 = cols[2].Clues;

        // Assert
        Assert.Equal(expected1, actual1);
        Assert.Equal(expected2, actual2);
        Assert.Equal(expected3, actual3);
    }

    [Fact]
    public void OverwriteOverwritesCorrectly()
    {
        // Arrange
        Row r1 = new(3, []);
        Row r2 = new(3, []);
        Row r3 = new(3, []);
        Row r4 = new(3, []);

        var columns = Column.FromRows([r1, r2, r3, r4], [[], [], []]);
        var column = columns[0];

        column.Overwrite([null, null, true, true]);
        bool?[] expected = [null, true, false, true];

        // Act
        column.Overwrite([null, true, false, null]);
        var actual = column.Cells.Select(c => c.Value);

        // Assert
        Assert.Equal(expected, actual);
    }
}
