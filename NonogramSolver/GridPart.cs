namespace NonogramSolver;

public abstract class GridPart
{
    public int Size { get; init; }
    public Cell[] Cells { get; init; }
    public int[] Clues { get; init; }
    public bool IsComplete => !Cells.Any(c => c.Value == null);
    public int Complete => Cells.Count(c => c.Value.HasValue);
    public bool NeedsProcessing => Cells.Any(c => c.NeedsProcessing);

    public bool Overwrite(bool?[] newValues)
    {
        var changeMade = false;

        if (newValues.Length != Size)
        {
            throw new ArgumentException(nameof(newValues) + " has incorrect length");
        }

        for (int i = 0; i < Size; i++)
        {
            if (newValues[i].HasValue && Cells[i].Value != newValues[i])
            {
                Cells[i].Value = newValues[i];
                changeMade = true;
                Cells[i].NeedsProcessing = true;
            }
            else
            {
                Cells[i].NeedsProcessing = false;
            }
        }

        return changeMade;
    }
}
