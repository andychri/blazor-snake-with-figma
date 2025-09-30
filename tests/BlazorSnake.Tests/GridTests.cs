using BlazorSnake.Components;

namespace BlazorSnake.Tests;

public class GridTests
{
    [Fact]
    public void Set_Grid_Dimensions_And_All_Cells_False()
    {
        var g = new Grid(3, 2);
        
        Assert.Equal(3, g.Rows);
        Assert.Equal(2, g.Columns);
        
        for (int r = 0; r < g.Rows; r++)
        for (int c = 0; c< g.Columns; c++)
            Assert.False(g.GetCell(r, c));
    }
    
    [Fact]
    public void Is_Cell_Inside_Grid()
    {
        var g = new Grid(3, 2);
        Assert.True(g.IsInside(0, 0));
        Assert.True(g.IsInside(2, 1));
        Assert.False(g.IsInside(-1, 0));
        
    }
}