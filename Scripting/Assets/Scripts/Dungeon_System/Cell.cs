using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Code_DungeonSystem
{
    public class Cell: MonoBehaviour
    {
        //Enemigo que tiene la celda
        [SerializeField] private Obstaculo OBS;

        //Texto desplegable
        [SerializeField] TextMesh txt;
        [SerializeField] private SpriteRenderer bg;
        
        //Ubicacion en espacio de matrix de la celda
        private int x, y;
        
        public Obstaculo Enemy { get => OBS;}
        public int X { get => x;}
        public int Y { get => y;}

        //Inicializacion de la celda
        public void CellConfig(Grid grid, int x, int y) 
        {
            //Se le inyecta la posicion
            this.x = x;
            this.y = y;

            //Se ubica en la posicion correspondiente en espacio de mundo
            transform.position = grid.GridToWorld(x, y);

            //Inicializa el enemigo
            OBS.SetUp();

            //Inicializa el texto
            txt.color = Color.green;
            txt.text = this.ToString();
        }

        //Sobre-escritura de la funcion para facilitar el despliegue de textos
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

        public void UpdateText()
        {
            txt.text = ToString();
        }

        public void ChangeText() 
        {
            txt.text = "";
            OBS = null;
            bg.color = Color.green;
        }
    }
}

