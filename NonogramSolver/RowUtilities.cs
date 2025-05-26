using System.Collections;

namespace NonogramSolver;

public static class RowUtilities
{
    public static IEnumerable<bool[]> CreateAllPossibilities(int size, int[] clues)
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
