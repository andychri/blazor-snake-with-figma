namespace BlazorSnake.Components;

public class Grid
{
    private bool[] _grid = [];
    public int Rows { get; }
    public int Columns { get; }

    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        InitializeGrid();
    }
    
    private void InitializeGrid()
    {
        _grid = new bool[Rows*Columns];    
    }
    
    /// <summary>
    /// Returns the 1D array index for the cell at (<paramref name="row"/>, <paramref name="column"/>).
    /// </summary>
    /// <param name="row">Current cell row in the range [0, _rows]</param>
    /// <param name="column">Current cell column in the range [0, _columns]</param>
    /// <returns>A zero based integer index for the _grid array</returns>
    public int IndexOf(int row, int column)
    {
        return row * Columns + column;
    }

    /// <summary>
    /// Returns the row of the cell in the 1D array at (<paramref name="index"/>).
    /// </summary>
    /// <param name="index">Index of the cells [row,col] pair</param>
    /// <returns>A zero based integer row for the _grid array</returns>
    public int RowOf(int index)
    {
        return index / Columns;
    }
    
    /// <summary>
    /// Returns the column of the cell in the 1D array at (<paramref name="index"/>).
    /// </summary>
    /// <param name="index">Index of the cells [row,col] pair</param>
    /// <returns>A zero based integer column for the _grid array</returns>
    public int ColumnOf(int index)
    {
        return index % Columns;
    }
    
    
    /// <summary>
    /// Checks if the [<paramref name="row"/>,<paramref name="column"/>] coordinate is within the bounds of the grid.
    /// </summary>
    /// <param name="row">Integer position of the row</param>
    /// <param name="column">Integer position of the column</param>
    /// <returns><see langword="false"/> if the cell is out of bounds; otherwise <see langword="true"/>.</returns>
    public bool IsInside(int row, int column)
    {
        return row < 0 || row >= Rows || column < 0 || column >= Columns;
    }

    /// <summary>
    /// Returns the array value at the [<paramref name="row"/>,<paramref name="column"/>] coordinate.
    /// </summary>
    /// <param name="row">Integer position of the row</param>
    /// <param name="column">Integer position of the column</param>
    /// <returns><see langword="true"/> if the cell is occupied by the snake; otherwise <see langword="false"/>.</returns>
    public bool GetCell(int row, int column)
    {
        var index = IndexOf(row, column);
        return _grid[index];
    }
}