namespace NonogramSolver.Tests;

public class GridTests
{
    [Fact]
    public void GridConstructorInitializesRowsAndColumns()
    {
        // Arrange
        int sizeX = 5;
        int sizeY = 7;
        int[][] rowClues = [[1], [2], [1], [2], [1], [2], [1]];
        int[][] columnClues = [[1], [2], [1], [2], [1]];

        // Act
        var grid = new Grid(sizeX, sizeY, rowClues, columnClues);

        // Assert
        Assert.Equal(sizeY, grid.Rows.Length);
        Assert.Equal(sizeX, grid.Columns.Length);
    }
    [Fact]
    public void GridConstructorThrowsIfRowCluesLengthDoesNotMatchSize()
    {
        // Arrange
        int sizeX = 5;
        int sizeY = 7;
        int[][] rowClues = [[1], [2, 3]];
        int[][] columnClues = [[1], [2], [3]];

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Grid(sizeX, sizeY, rowClues, columnClues));
    }
}
