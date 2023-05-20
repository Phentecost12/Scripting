using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

namespace Code_DungeonSystem
{
    public class DungeonManager : MonoBehaviour
    {
        //Configuracion de la matrix 
        private Grid grid;
        [Header("Tamaño de la cuadricula")]
        [SerializeField] private int width;
        [SerializeField] private int height;
        [Header("Tamaño de las celdas")]
        [SerializeField] private float cellSize;
        [Header("Celda")]
        [SerializeField] private Sprite cellSprite;
        public GameObject enemyPrefab;
        public Cell lastCell;
        
        //Singleton
        public static DungeonManager Instance { get; private set; } = null;
        public Grid Grid { get => grid;}

        //Singleton
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            GenerateDungeon(width, height, cellSize);
        }

        //Crea e inicializa la matriz
        private void GenerateDungeon(int width, int height, float cellSize) 
        {
            grid = new Grid(width, height, cellSize);

            //Toma la referencia de la celda final
            lastCell = grid.GetValue(width - 1, height - 1);
        }

        //Devuelve la celda inicial 
        public Cell GetStartCell()
        {
            return grid.GetValue(0, 0);
        }
    }

    //Clase matrix
    public class Grid: MonoBehaviour
    {
        //Numero de celdas que crea a lo ancho
        private int width;

        //Numero de celdas que crea a lo alto
        private int height;

        //Tamaño de las celdas
        private float cellSize;

        //Matriz de celdas
        private Cell[,] gridArray;

        public int GetWidth { get => width; }
        public int GetHeight { get => height; }

        //Constructor
        public Grid(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            gridArray = new Cell[width, height];


            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    //Se llama a la fabrica para crear la celda
                    gridArray[x, y] = Factory.Instance.CreateCell();

                    //Se inicializa la celda
                    gridArray[x, y].CellConfig(this,x,y);
                }
            } 
        }

        //Transforma Coordenadas de matriz a espacio de mundo
        public Vector3 GridToWorld(int x, int y)
        {
            return new Vector3(x, y) * cellSize;
        }

        //Transforma coordenadas de mundo a espacio de matriz
        public void WorldToGrid(Vector3 WorldPos, out int x, out int y)
        {
            x = Mathf.FloorToInt(WorldPos.x / cellSize);
            y = Mathf.FloorToInt(WorldPos.y / cellSize);
        }

        //Devuelve la celda que corresponde al espacio de matrix
        public Cell GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return gridArray[x, y];
            }
            else
            {
                return default(Cell);
            }
        }

        //Devuelve la celda que corresponde al espacio de mundo
        public Cell GetValue(Vector3 WorldPos)
        {
            int x, y;
            WorldToGrid(WorldPos, out x, out y);
            return GetValue(x, y);
        }
    }
}
