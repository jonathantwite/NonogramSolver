using System.Text;

namespace NonogramSolver;

public class Grid
{
    public int SizeX { get; init; }
    public int SizeY { get; init; }

    public Row[] Rows { get; init; }
    public Column[] Columns { get; init; }

    public bool IsComplete => !Rows.Any(r => !r.IsComplete) && !Columns.Any(c => !c.IsComplete);
    public decimal Complete => (decimal)Rows.Sum(r => r.Complete) / (SizeX * SizeY);

    public Grid(int sizeX, int sizeY, int[][] rowsClues, int[][] columnsClues)
    {
        if (rowsClues.Length != sizeY)
        {
            throw new ArgumentException("The number of row clue entries does not match the number of rows");
        }

        if (columnsClues.Length != sizeX)
        {
            throw new ArgumentException("The number of column clue entries does not match the number of columns");
        }

        SizeX = sizeX;
        SizeY = sizeY;

        Rows = new Row[sizeY];
        for (int i = 0; i < sizeY; i++)
        {
            Rows[i] = new Row(sizeX, rowsClues[i]);
        }

        Columns = Column.FromRows(Rows, columnsClues);
    }

    public bool ProcessAllRows() => ProcessAllGridParts(Rows);

    public bool ProcessAllColumns() => ProcessAllGridParts(Columns);

    private bool ProcessAllGridParts(GridPart[] rowOrColumn)
    {
        var changeMade = false;
        foreach (var row in rowOrColumn)
        {
            if (!row.NeedsProcessing)
            {
                continue;
            }

            //Console.Clear();
            //Console.WriteLine($"Processing row {string.Join(", ", row.Clues)}");

            IEnumerable<bool[]> allPossibilities = [];
            if (row.Clues.Length <= 4)
            {
                allPossibilities = RowUtilities.CreateAllPossibilitiesByGap(row.Size, row.Clues);
            }
            else
            {
                allPossibilities = RowUtilities.CreateAllPossibilitiesBruteForce(row.Size, row.Clues);
            }

            var possibilities = RowUtilities.FilterToPossibilitiesThatFit(allPossibilities, row.Cells);

            var certainties = RowUtilities.GetAllDefinites(possibilities.ToArray());

            var change = row.Overwrite(certainties);
            changeMade = changeMade || change;
        }

        return changeMade;
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        foreach (var row in Rows)
        {
            output.AppendLine(row.ToString());
        }

        return output.ToString();
    }
}
