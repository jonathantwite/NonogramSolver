# Nonogram Solver

This application will solve most Nonograms created for humans to solve.

It works in what I call a "row then column" processing style, working like a human would.  The basic outline of the algorithm is as follows:

1. A row is selected.
1. A list of every possible combination of filled and blanks is created.
1. This list is then filtered to only the possibilities that fulfill at row's clues.
1. The list is then further filtered so that if we know a cell definitely has a value (filled or blank), only the possibilities where that cell is this known value remain.
1. Finally, for each cell, we look at all of the remaining possibilities.  If they are all the same value (filled or blank), we take that as a correct value and add it as a known value to the results grid.
1. The process is then repeated for the remaining rows.
1. The process is then repeated for each column.
1. The process of processing rows and columns is then repeated until either the grid is complete, or no changes are made by a full (row and column) cycle.

## Notes

Rows and Columns are fundamentally a very similar concept and we need the same style of processing to happen to both.  Therefore they both inherit from an abstract base class that holds the majority of the logic.  The major difference is how they are created, with the rows be created "normally" and the columns being created out of these resultant rows.

Cells are represented by an object (rather than a simple `bool`) so that the their value can be shared by reference between the `Row` and the `Column` that contains the `Cell`.  This allows it to be updated by either.

