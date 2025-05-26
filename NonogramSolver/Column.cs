namespace NonogramSolver;

public class Column : GridPart
{
    private Column() { }

    public static Column[] FromRows(Row[] rows, int[][] columnClues)
    {
        if(columnClues.Length != rows[0].Cells.Length)
        {
            throw new ArgumentException("The number of column clue entries does not match the number of columns");
        }

        List<Column> columns = [];
        var size = rows.Length;

        for (int i = 0; i < rows[0].Cells.Length; i++)
        {
            var column = new Column
            {
                Size = size,
                Cells = new Cell[size],
                Clues = columnClues[i]
            };

            for (int j = 0; j < size; j++)
            {
                column.Cells[j] = rows[j].Cells[i];
            }

            columns.Add(column);
        }

        return columns.ToArray();
    }
}
