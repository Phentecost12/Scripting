/*using System;
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

        public Obstaculo OBS = null;

        public CellTesting lastNode;


        public CellTesting(Grid<CellTesting> grid, int x, int y) 
        {
            this.grid = grid;
            this.x = x;
            this.y = y;

            Random random = new Random();

            int r = random.Next(0, 100);

            OBS = GetObstacleToSpawn(r);
        }

        public Obstaculo GetObstacleToSpawn(int r)
        {
            Obstaculo P = new Obstaculo(0);

            if (r > 0 && r <= 5)
            {
                P = new Angel(1);
            }

            if (r > 6 && r <= 33)
            {
                P = new Mago(x);
            }

            if (r > 34 && r <= 100)
            {
                P = new Guardia(x);
            }

            return P;
        }

        public override string ToString() 
        {
            return OBS.Power + " , "+x + " , " + y;
        }

    }
}
*/