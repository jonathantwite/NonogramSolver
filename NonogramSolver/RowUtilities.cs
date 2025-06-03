using System.Collections;

namespace NonogramSolver;

public static class RowUtilities
{
    public static IEnumerable<bool[]> CreateAllPossibilitiesByGap(int size, int[] clues)
    {
        List<bool[]> result = [];

        if (clues.Length == 1 && clues[0] == 0)
        {
            return [new bool[size]];
        }

        int[] gaps = new int[clues.Length];

        // At least one gap between blocks, except the first (start of line)
        Array.Fill(gaps, 1);
        gaps[0] = 0;

        var tooBig = false;

        var haveIncreasedAGap = true;

        while (haveIncreasedAGap/* && gaps.Sum() + clues.Sum() <= size*/)
        {
            //Console.WriteLine($"Trying gaps: {string.Join(", ", gaps)}");
            List<bool> row = [];
            tooBig = false;
            for (int i = 0; i < clues.Length; i++)
            {
                row.AddRange(ArrayHelper.CreateFilled(gaps[i], false));
                row.AddRange(ArrayHelper.CreateFilled(clues[i], true));
                if (row.Count > size)
                {
                    tooBig = true;
                    break;
                }
            }

            if (!tooBig)
            {
                var rowArray = row.ToArray();
                Array.Resize(ref rowArray, size);
                result.Add(rowArray);
            }


            haveIncreasedAGap = false;

            for (int i = 0; i < gaps.Length; i++)
            {
                if (gaps[i] <= (size - clues.Sum() - (clues.Count() - 1)))
                {
                    gaps[i]++;
                    haveIncreasedAGap = true;
                    break;
                }
                else
                {
                    gaps[i] = i == 0 ? 0 : 1; // Reset this gap
                }
            }
        }


        return result;
    }

    public static IEnumerable<bool[]> CreateAllPossibilitiesBruteForce(int size, int[] clues)
    {
        List<bool[]> result = [];
        var max = Math.Pow(2, size) - 1;
        for (int i = 0; i < max; i++)
        {
            BitArray b = new([i]);
            var bits = new bool[b.Count];
            b.CopyTo(bits, 0);

            result.Add(bits.Take(size).ToArray());
        }

        return result.Where(x => RowFulfillsClues(x, clues)).ToList();
    }

    public static bool RowFulfillsClues(bool[] row, int[] clues)
    {
        List<int> blocks = [];
        int currentBlock = 0;

        for (int i = 0; i < row.Length; i++)
        {
            if (row[i])
            {
                currentBlock++;
            }
            else
            {
                if (currentBlock > 0)
                {
                    blocks.Add(currentBlock);
                    currentBlock = 0;
                }
            }
        }

        if(currentBlock > 0)
        {
            blocks.Add(currentBlock);
        }

        if (!blocks.Any())
        {
            blocks.Add(0);
        }

        if(blocks.Count != clues.Length)
        {
            return false;
        }

        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] != clues[i])
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<bool[]> FilterToPossibilitiesThatFit(IEnumerable<bool[]> possibilities, Cell[] currentRow)
    {
        foreach (var possibility in possibilities)
        {
            var match = true;
            for (int i = 0; i < possibility.Length; i++)
            {
                if (currentRow[i].Value != null && currentRow[i].Value != possibility[i])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                yield return possibility;
            }
        }
    }

    public static bool?[] GetAllDefinites(bool[][] allPossibilities)
    {
        var result = new bool?[allPossibilities[0].Length];

        for (int i = 0; i < result.Length; i++)
        {
            bool? value = null;
            for (int j = 0; j < allPossibilities.Length; j++)
            {
                if(value.HasValue && allPossibilities[j][i] != value)
                {
                    value = null;
                    break;
                }
                else if (!value.HasValue)
                {
                    value = allPossibilities[j][i];
                }
            }

            result[i] = value;
        }
        return result;
    }
}
