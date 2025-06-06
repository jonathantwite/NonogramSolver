using NonogramSolver;
using System.Diagnostics;

int delayMS = 100;
bool displayWorking = false;

//int sizeX = 15;
//int sizeY = 15;
//int[][] rowClues = [
//    [6],
//    [1,1,2,2],
//    [2,2,2],
//    [1,1,2,1,1],
//    [7,2],
//    [2,7,1,1],
//    [1,9,2],
//    [1,6,1],
//    [8,4],
//    [2,1,1,1,1,2],
//    [1,3,1,4],
//    [2,4,2],
//    [2,1,2,1],
//    [2,1,1],
//    [3,2]];
//
//int[][] columnClues = [
//    [2,2,3],
//    [1,1,2,2],
//    [2,1,1,1],
//    [6],
//    [6,1,1],
//    [1,9,1],
//    [1,5,2,1],
//    [2,6,1,2],
//    [1,5,4],
//    [2,1,3,1,1],
//    [2,3,1,1,1],
//    [1,3,3],
//    [3],
//    [2,1,3,2,1],
//    [6,2]];

int sizeX = 30;
int sizeY = 30;
int[][] rowClues = [
    [5,1],
    [3,2,1,1],
    [1,7,4,2],
    [12,2,3],
    [8,1,2,3],
    [8,1,1,4,2],
    [3,1,2,4,3],
    [5,1,3,2],
    [5,3,10,3,2],
    [3,1,1,1,1,1,1],

    [2,1,4,5,1,7],
    [1,2,7,2,1,6],
    [2,2,1,11,2],
    [3,2,1,2],
    [4,6,3,5,3,1],
    [2,4,2,3,3,2],
    [2,1,4,1,2,1,1],
    [2,2,1,2,2,2,4,1,2],
    [5,1,1,4,1,1,3],
    [2,1,1,2,2,2,4,2],

    [1,2,1,8,4,4],
    [1,1,1,1,2,1,4,3,1],
    [1,4,1,1,1],
    [1,2,7,16],
    [2,5,1,3,2,2,2,1],
    [3,3,2,1,1,2,2,5,1],
    [4,2,2,3,3,3,2],
    [11,2,3,5,3],
    [29],
    [29],
    ];

int[][] columnClues = [
    [1,3,2,6],
    [2,4,4,6],
    [6,4,6,5],
    [8,4,3,2,4],
    [1,6,2,2,2,1,2,3],
    [2,3,3,2,3,3,3],
    [1,5,1,2,6,3],
    [1,4,1,3,1,3,3,3],
    [1,3,5,2,2,5],
    [4,1,1,2,1,5,5],

    [4,2,2,1,3,1,3],
    [2,2,2,2,2,7,2],
    [2,7,1,3,4],
    [1,1,3,1,1,2,2,3],
    [1,1,1,1,3,6,2],
    [1,3,2,2,1,2,3],
    [1,2,1,1,1,1,4],
    [1,1,2,5,7],
    [1,1,7,4,2],
    [1,1,2,1,1,3],

    [1,1,1,5,1,5],
    [1,5,1,2,2,1,5],
    [1,1,3,2,2,1,4],
    [2,2,1,1,2,5,3,3],
    [12,2,1,4,2],
    [1,2,2,2,2,5,1,2,2],
    [1,1,2,1,3,4,2],
    [2,1,3,2,2,1,3,3],
    [7,4,3,4,4],
    [11,2,4,1],
    ];

Stopwatch sw = new Stopwatch();
sw.Start();

Grid grid = new Grid(sizeX, sizeY, rowClues, columnClues);

var changeMade = true;
while (changeMade && !grid.IsComplete)
{
    var rowChange = grid.ProcessAllRows();
    Display();

    var colChange = grid.ProcessAllColumns();
    Display();

    changeMade = rowChange || colChange;
}

Display(true);
Console.WriteLine(string.Format("{0:P}", grid.Complete) + " completed in " + (sw.ElapsedMilliseconds / 1000.0M) + "s");


void Display(bool showGrid = false)
{
    Console.Clear();
    if (displayWorking || showGrid)
    {
        Console.WriteLine(grid.ToString());
        Thread.Sleep(delayMS);
    }
    else
    {
        Console.WriteLine("Complete: " + string.Format("{0:P}", grid.Complete));
    }
}

