using BenchmarkDotNet.Attributes;

namespace NonogramSolver.Benchmarks;
public class CreateAllPossibilitiesBenchmarks
{

    [Benchmark]public void RunCreateAllPossibilitiesByGap05FewSparse() => RowUtilities.CreateAllPossibilitiesByGap(5, [1]);
    [Benchmark]public void RunCreateAllPossibilitiesBruteForce05FewSparse() => RowUtilities.CreateAllPossibilitiesBruteForce(5, [1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap05FewFull() => RowUtilities.CreateAllPossibilitiesByGap(5, [4]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce05FewFull() => RowUtilities.CreateAllPossibilitiesBruteForce(5, [4]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap05ManySparse() => RowUtilities.CreateAllPossibilitiesByGap(5, [1,1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce05ManySparse() => RowUtilities.CreateAllPossibilitiesBruteForce(5, [1, 1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap05ManyFull() => RowUtilities.CreateAllPossibilitiesByGap(5, [2, 2]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce05ManyFull() => RowUtilities.CreateAllPossibilitiesBruteForce(5, [2, 2]);



    [Benchmark] public void RunCreateAllPossibilitiesByGap10FewSparse() => RowUtilities.CreateAllPossibilitiesByGap(10, [1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce10FewSparse() => RowUtilities.CreateAllPossibilitiesBruteForce(10, [1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap10FewFull() => RowUtilities.CreateAllPossibilitiesByGap(10, [8]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce10FewFull() => RowUtilities.CreateAllPossibilitiesBruteForce(10, [8]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap10ManySparse() => RowUtilities.CreateAllPossibilitiesByGap(10, [1, 1, 1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce10ManySparse() => RowUtilities.CreateAllPossibilitiesBruteForce(10, [1, 1, 1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap10ManyFull() => RowUtilities.CreateAllPossibilitiesByGap(10, [1, 2, 2, 1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce10ManyFull() => RowUtilities.CreateAllPossibilitiesBruteForce(10, [1, 2, 2, 1]);



    [Benchmark] public void RunCreateAllPossibilitiesByGap15FewSparse() => RowUtilities.CreateAllPossibilitiesByGap(15, [1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce15FewSparse() => RowUtilities.CreateAllPossibilitiesBruteForce(15, [1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap15FewFull() => RowUtilities.CreateAllPossibilitiesByGap(15, [13]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce15FewFull() => RowUtilities.CreateAllPossibilitiesBruteForce(15, [13]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap15ManySparse() => RowUtilities.CreateAllPossibilitiesByGap(15, [1, 1, 1, 1, 1, 1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce15ManySparse() => RowUtilities.CreateAllPossibilitiesBruteForce(10, [1, 1, 1, 1, 1, 1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap15ManyFull() => RowUtilities.CreateAllPossibilitiesByGap(15, [2, 2, 2, 2, 2]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce15ManyFull() => RowUtilities.CreateAllPossibilitiesBruteForce(15, [2, 2, 2, 2, 2]);



    [Benchmark] public void RunCreateAllPossibilitiesByGap20FewSparse() => RowUtilities.CreateAllPossibilitiesByGap(20, [1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce20FewSparse() => RowUtilities.CreateAllPossibilitiesBruteForce(15, [1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap20FewFull() => RowUtilities.CreateAllPossibilitiesByGap(20, [17]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce20FewFull() => RowUtilities.CreateAllPossibilitiesBruteForce(20, [17]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap20ManySparse() => RowUtilities.CreateAllPossibilitiesByGap(20, [1, 1, 1, 1, 1, 1, 1, 1, 1]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce20ManySparse() => RowUtilities.CreateAllPossibilitiesBruteForce(20, [1, 1, 1, 1, 1, 1, 1, 1, 1]);

    [Benchmark] public void RunCreateAllPossibilitiesByGap20ManyFull() => RowUtilities.CreateAllPossibilitiesByGap(20, [3, 3, 3, 3, 2]);
    [Benchmark] public void RunCreateAllPossibilitiesBruteForce20ManyFull() => RowUtilities.CreateAllPossibilitiesBruteForce(20, [3, 3, 3, 3, 2]);
}
