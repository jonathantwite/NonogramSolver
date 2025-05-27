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
        SizeX = sizeX;
        SizeY = sizeY;

        Rows = new Row[sizeY];
        for (int i = 0; i < sizeY; i++)
        {
            Rows[i] = new Row(sizeX, rowsClues[i]);
        }

        Columns = Column.FromRows(Rows, columnsClues);
    }

    public bool ProcessAllRows()
    {
        var changeMade = false;
        foreach(var row in Rows)
        {
            if (!row.NeedsProcessing)
            {
                continue;
            }
            var possibilities = RowUtilities.CreateAllPossibilities(row.Size, row.Clues);
            var possibilitiesThatFit = RowUtilities.FilterToPossibilitiesThatFit(possibilities, row.Cells);
            var certainties = RowUtilities.GetAllDefinites(possibilitiesThatFit.ToArray());
            
            var change = row.Overwrite(certainties);
            changeMade = changeMade || change;
        }

        return changeMade;
    }

    public bool ProcessAllColumns()
    {
        var changeMade = false;
        foreach(var col in Columns)
        {
            if (!col.NeedsProcessing)
            {
                continue;
            }
            var possibilities = RowUtilities.CreateAllPossibilities(col.Size, col.Clues);
            var possibilitiesThatFit = RowUtilities.FilterToPossibilitiesThatFit(possibilities, col.Cells);
            var certainties = RowUtilities.GetAllDefinites(possibilitiesThatFit.ToArray());

            var change = col.Overwrite(certainties);
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
