using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    private int MOVE_DIAGONAL_COST = 14;
    private int MOVE_STRAIGHT_COST = 10;

    private Grid<CellTesting> grid;
    private List<CellTesting> openList;
    private List<CellTesting> closeList;
    public PathFinding(int width, int height) 
    {
        grid = new Grid<CellTesting>(width,height,10f, (Grid<CellTesting> g, int x, int y) => new CellTesting(g, x,y));
    }

    public List<CellTesting> FingPath(int startX, int startY, int endX, int endY) 
    {
        CellTesting startCell = grid.GetValue(startX, startY);
        CellTesting endCell = grid.GetValue(endX, endY);

        openList= new List<CellTesting> { startCell };
        closeList= new List<CellTesting>();

        for (int x = 0; x < grid.GetWidth; x++)
        {
            for (int y = 0; y < grid.GetHeight; y++)
            {
                CellTesting cell = grid.GetValue(x, y);
                cell.gCost = int.MaxValue;
                cell.CalculateFCost();
                cell.lastNode = null;
            }
        }

        startCell.gCost = 0;
        startCell.hCost = CalculateDistance(startCell,endCell);
        startCell.CalculateFCost();

        while (openList.Count>0)
        {
            CellTesting currentCell = GetLowesFcostCell(openList);
            if (currentCell == endCell) 
            {
                return CalculatePath(endCell);
            }

            openList.Remove(currentCell);
            closeList.Add(currentCell);

            foreach (CellTesting cell in GetNeighboursList(currentCell))
            {
                if (closeList.Contains(cell)) continue;

                int tentativeGCost = currentCell.gCost + CalculateDistance(currentCell, cell);
                if (tentativeGCost < cell.gCost) 
                {
                    cell.lastNode = currentCell;
                    cell.gCost = tentativeGCost;
                    cell.hCost = CalculateDistance(cell, endCell);
                    cell.CalculateFCost();

                    if (!openList.Contains(cell))
                    {
                        openList.Add(cell);
                    }
                }
                
            }
        }

        return null;
    }

    private List<CellTesting> GetNeighboursList(CellTesting currentCell) 
    {
        List<CellTesting> neighbourtsList= new List<CellTesting>();

        //Left
        if (currentCell.x - 1 >= 0)
        {
            neighbourtsList.Add(grid.GetValue(currentCell.x -1, currentCell.y));
        }
        //Right
        if (currentCell.x + 1 < grid.GetWidth)
        {
            neighbourtsList.Add(grid.GetValue(currentCell.x + 1, currentCell.y));
        }
        //Up
        if (currentCell.y + 1 < grid.GetHeight)
        {
            neighbourtsList.Add(grid.GetValue(currentCell.x, currentCell.y + 1));
        }
        //Down
        if (currentCell.y - 1 >= 0)
        {
            neighbourtsList.Add(grid.GetValue(currentCell.x, currentCell.y-1));
        }

        return neighbourtsList;
    }

    private List<CellTesting> CalculatePath(CellTesting endCell) 
    {
        List<CellTesting> path = new List<CellTesting>();

        path.Add(endCell);
        CellTesting currentCell = endCell;

        while (currentCell.lastNode != null) 
        {
            path.Add(currentCell.lastNode);
            currentCell = currentCell.lastNode;
        }
        path.Reverse();
        return path;
    }

    private int CalculateDistance(CellTesting a, CellTesting b)  
    {
        int xDistance = Mathf.Abs(a.x- b.x);
        int yDistance = Mathf.Abs(a.y- b.y);
        int remaining = Mathf.Abs(xDistance- yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining; 
    }

    private CellTesting GetLowesFcostCell(List<CellTesting> cellList) 
    {
        CellTesting low = cellList[0];
        for (int i = 0; i < cellList.Count; i++)
        {
            if (cellList[i].fCost < low.fCost)
            {
                low = cellList[i];
            }
        }

        return low;
    }
}
