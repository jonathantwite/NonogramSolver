# Benchmarks

```
cd NonogramSolver.Benchmarks
dotnet run -c Release
```

## Results

| Method                             | Size | Number of clues | Amount of filled squares | Mean             | Error           | StdDev           |
|------------------------------------------------ |-----------------:|----------------:|-----------------:|
| **CreateAllPossibilitiesByGap** | 05 | Few | Sparse       |         434.3 ns |         8.49 ns |         13.71 ns |
| CreateAllPossibilitiesBruteForce | 05 | Few | Sparse  |       2,676.6 ns |        53.35 ns |         84.63 ns |
|
| **CreateAllPossibilitiesByGap** | 05 | Few | Full         |         203.1 ns |         4.07 ns |          8.41 ns |
| CreateAllPossibilitiesBruteForce | 05 | Few | Full    |       2,696.6 ns |        53.44 ns |         63.62 ns |
|
| **CreateAllPossibilitiesByGap** | 05 | Many | Sparse      |       1,182.5 ns |        23.29 ns |         32.65 ns |
| CreateAllPossibilitiesBruteForce | 05 | Many | Sparse |       2,639.7 ns |        45.50 ns |         35.52 ns |
|
| **CreateAllPossibilitiesByGap** | 05 | Many | Full        |         212.0 ns |         4.15 ns |          4.26 ns |
| CreateAllPossibilitiesBruteForce | 05 | Many | Full   |       2,663.3 ns |        47.33 ns |         87.73 ns |
|
| **CreateAllPossibilitiesByGap** | 10 | Few | Sparse       |         855.2 ns |        16.42 ns |         18.25 ns |
| CreateAllPossibilitiesBruteForce | 10 | Few | Sparse  |     134,191.7 ns |     2,619.53 ns |      2,322.14 ns |
|
| **CreateAllPossibilitiesByGap** | 10 | Few | Full         |         279.6 ns |         5.57 ns |         12.22 ns |
| CreateAllPossibilitiesBruteForce | 10 | Few | Full    |     132,444.4 ns |     2,563.25 ns |      2,272.25 ns |
|
| **CreateAllPossibilitiesByGap** | 10 | Many | Sparse      |      32,771.9 ns |       452.41 ns |        423.18 ns |
| CreateAllPossibilitiesBruteForce | 10 | Many | Sparse |     131,345.1 ns |     2,574.31 ns |      3,773.39 ns |
|
| **CreateAllPossibilitiesByGap** | 10 | Many | Full        |       4,105.3 ns |        76.25 ns |         71.33 ns |
| CreateAllPossibilitiesBruteForce | 10 | Many | Full   |     132,078.5 ns |     2,461.17 ns |      3,974.33 ns |
|
| **CreateAllPossibilitiesByGap** | 15 | Few | Sparse       |       1,198.6 ns |        17.48 ns |         14.59 ns |
| CreateAllPossibilitiesBruteForce | 15 | Few | Sparse  |   9,719,536.7 ns |   186,413.27 ns |    221,911.76 ns |
|
| **CreateAllPossibilitiesByGap** | 15 | Few | Full         |         284.3 ns |         4.78 ns |          6.54 ns |
| CreateAllPossibilitiesBruteForce | 15 | Few | Full    |   9,682,823.6 ns |   182,657.51 ns |    170,857.95 ns |
|
| CreateAllPossibilitiesByGap | 15 | Many | Sparse      |   4,596,019.5 ns |    52,717.05 ns |     46,732.30 ns |
| **CreateAllPossibilitiesBruteForce** | 15 | Many | Sparse |     132,399.1 ns |     2,646.98 ns |      2,346.48 ns |
|
| **CreateAllPossibilitiesByGap** | 15 | Many | Full        |      10,527.8 ns |       206.59 ns |        289.61 ns |
| CreateAllPossibilitiesBruteForce | 15 | Many | Full   |   9,599,695.2 ns |   181,289.75 ns |    229,273.50 ns |
|
| **CreateAllPossibilitiesByGap** | 20 | Few | Sparse       |       1,627.4 ns |        30.76 ns |         36.61 ns |
| CreateAllPossibilitiesBruteForce | 20 | Few | Sparse  |   9,701,643.2 ns |   193,065.82 ns |    306,222.88 ns |
|
| **CreateAllPossibilitiesByGap** | 20 | Few | Full         |         381.1 ns |         7.64 ns |         12.12 ns |
| CreateAllPossibilitiesBruteForce | 20 | Few | Full    | 434,768,728.3 ns | 8,627,493.77 ns | 18,008,793.65 ns |
|
| **CreateAllPossibilitiesByGap** | 20 | Many | Sparse      | 104,756,561.0 ns | 2,071,262.17 ns |  2,385,268.59 ns |
| CreateAllPossibilitiesBruteForce | 20 | Many | Sparse | 431,147,894.7 ns | 8,567,990.31 ns | 14,779,363.48 ns |
|
| **CreateAllPossibilitiesByGap** | 20 | Many | Full        |      70,055.5 ns |       738.41 ns |        654.58 ns |
| CreateAllPossibilitiesBruteForce | 20 | Many | Full   | 418,876,297.1 ns | 8,340,785.00 ns | 13,468,814.13 ns |