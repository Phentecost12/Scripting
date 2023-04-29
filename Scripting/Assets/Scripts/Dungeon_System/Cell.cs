using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Code_DungeonSystem
    {
    public class Cell
    {
        Obstaculo OBS = new Obstaculo(0,null);
        Grid<Cell> grid;
        
        
        int x, y;

        public Obstaculo Enemy { get => OBS;}
        public int X { get => x;}
        public int Y { get => y;}

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
            Obstaculo P = new Obstaculo(0, this);

            if (r > 0 && r <= 5)
            {
                P = new Angel(1,this);
            }

            if (r > 6 && r <= 33)
            {
                P = new Mago(x,this);
            }

            if (r > 34 && r <= 84)
            {
                P = new Guardia(x,this);
            }

            if (r > 85 && r <= 100)
            {
                P = new Chest(x,this);
            }

            return P;
        }

        public override string ToString()
        {
            return OBS.Power.ToString() + " ,Tipo " + OBS.GetType();
        }

        public void ChangeText() 
        {
            DungeonManager.Instance.Grid.GetText(x, y).text = "";
            OBS = null;
            DungeonManager.Instance.Grid.GetCellRender(x,y).color = Color.green;
        }

    }
}

