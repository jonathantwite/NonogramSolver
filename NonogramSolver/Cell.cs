namespace NonogramSolver;

public class Cell
{
    public bool? Value { get; set; }
    public bool NeedsProcessing { get; set; } = true;

    public override string ToString()
    {
        return Value == true ? "X" : Value == false ? "·" : " ";
    }
}
