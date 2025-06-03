namespace NonogramSolver;

public class Row : GridPart
{
    public Row(int size, int[] clues)
    {
        if(clues.Sum() + clues.Length - 1 > size)
        {
            throw new ArgumentException("Clues too long for size");
        }
        Size = size;
        Cells = new Cell[size];
        ArrayHelper.Fill(Cells, () => new Cell());
        Clues = clues;
    }

    public override string ToString()
    {
        return "|" + string.Join("|", Cells.Select(c => c.ToString())) + "|";
    }
}
