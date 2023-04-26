using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code_DungeonSystem
    {
    public class Cell
    {
        Obstaculo OBS = new Obstaculo(0);
        Grid<Cell> grid;
        
        int x, y;

        public Cell(Grid<Cell> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;

            System.Random random= new System.Random();

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
            return OBS.Power.ToString() + " ,Tipo " + OBS.GetType();
        }

    }
}

