using System;
using System.Collections.Generic;
using System.Text;
//using ClasesVacias;

namespace Code_DungeonSystem
{
    public class CellTesting
    {

        private Grid<CellTesting> grid;
        public int x;
        public int y;

        public int gCost;
        public int hCost;
        public int fCost;

        public CellTesting lastNode;
        public CellTesting(Grid<CellTesting> grid, int x, int y) 
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void CalculateFCost() 
        {
            fCost = gCost + hCost;
        }

        public override string ToString() 
        {
            return x + "," + y;
        }

    }
}
