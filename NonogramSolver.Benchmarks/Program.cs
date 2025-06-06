using BenchmarkDotNet.Running;
using NonogramSolver.Benchmarks;

var summary = BenchmarkRunner.Run<CreateAllPossibilitiesBenchmarks>();
