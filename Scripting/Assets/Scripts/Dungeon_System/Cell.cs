using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Code_DungeonSystem
{
    public class Cell: MonoBehaviour
    {
        [SerializeField] private Obstaculo OBS;
        [SerializeField] TextMesh txt;
        [SerializeField] private SpriteRenderer bg;
        
        private int x, y;
        
        public Obstaculo Enemy { get => OBS;}
        public int X { get => x;}
        public int Y { get => y;}

        public void CellConfig(Grid grid, int x, int y) 
        {
            this.x = x;
            this.y = y;

            transform.position = grid.GridToWorld(x, y);
            //grid.AdjustSize(this.gameObject);

            OBS.SetUp();

            txt.text = this.ToString();
        }

       /* public Obstaculo GetObstacleToSpawn() 
        {
            System.Random random = new System.Random();

            int r = random.Next(0, 100);

            Obstaculo P = new Obstaculo(0, this);

            if (r > 0 && r <= 5)
            {
                P = new Angel(1,this);
            }

            if (r > 6 && r <= 33)
            {
                P = new Guardia(x,this);
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
        }*/

        public override string ToString()
        {
            string r = OBS.Power.ToString();

            if (OBS is Mago) 
            {
                Mago m = (Mago)OBS;
                r += " \n";
                r += m.Element;
            }
            return r;
        }

        public void ChangeText() 
        {
            txt.text = "";
            OBS = null;
            bg.color = Color.green;
        }
    }
}

