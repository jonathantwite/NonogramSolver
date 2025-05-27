using NonogramSolver;
using System.Diagnostics;

int sizeX = 15;
int sizeY = 15;
int delayMS = 100;
bool displayWorking = true;

int[][] rowClues = [
    [6],
    [1,1,2,2],
    [2,2,2],
    [1,1,2,1,1],
    [7,2],
    [2,7,1,1],
    [1,9,2],
    [1,6,1],
    [8,4],
    [2,1,1,1,1,2],
    [1,3,1,4],
    [2,4,2],
    [2,1,2,1],
    [2,1,1],
    [3,2]];

int[][] columnClues = [
    [2,2,3],
    [1,1,2,2],
    [2,1,1,1],
    [6],
    [6,1,1],
    [1,9,1],
    [1,5,2,1],
    [2,6,1,2],
    [1,5,4],
    [2,1,3,1,1],
    [2,3,1,1,1],
    [1,3,3],
    [3],
    [2,1,3,2,1],
    [6,2]];

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

