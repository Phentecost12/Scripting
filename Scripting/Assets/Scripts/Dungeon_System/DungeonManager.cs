using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Code_DungeonSystem
{
    class DungeonManager : MonoBehaviour
    {
        private Grid grid;
        private Camera Cam;
        [Header("Tamaño de la cuadricula")]
        [SerializeField] private int width;
        [SerializeField] private int height;
        [Header("Tamaño de las celdas")]
        [SerializeField] private float cellSize;

        private void Start()
        {
            Cam = Camera.main;
            GenerateDungeon(width, height, cellSize);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 WorldPos = Cam.ScreenToWorldPoint(Input.mousePosition);
                WorldPos.z = 0;
                grid.SetValue(WorldPos, 56);
            }
        }

        private void GenerateDungeon(int width, int height, float cellSize) 
        {
            grid = new Grid(width, height, cellSize);
        }
    }

    public class Grid
    {
        private int width;
        private int height;
        private float cellSize;
        private Cell[,] gridArray;
        private TextMesh[,] debugTextMesh;

        public Grid(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            gridArray = new Cell[width, height];
            debugTextMesh = new TextMesh[width, height];

            int contador = 0;
            for (int i = 0; i < gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridArray.GetLength(1); j++)
                {
                    gridArray[i, j] = new Cell();
                    gridArray[i, j].ID = contador;
                    debugTextMesh[i, j] = CreateWorldText(null, gridArray[i, j].ID.ToString(), GridToWorld(i, j) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 5000);
                    Debug.DrawLine(GridToWorld(i, j), GridToWorld(i, j + 1), Color.white, 100f);
                    Debug.DrawLine(GridToWorld(i, j), GridToWorld(i + 1, j), Color.white, 100f);
                    contador++;
                }
            }
            Debug.DrawLine(GridToWorld(0, height), GridToWorld(width, height), Color.white, 100f);
            Debug.DrawLine(GridToWorld(width, 0), GridToWorld(width, height), Color.white, 100f);
        }

        public Vector3 GridToWorld(int x, int y)
        {
            return new Vector3(x, y) * cellSize;
        }

        public void WorldToGrid(Vector3 WorldPos, out int x, out int y)
        {
            x = Mathf.FloorToInt(WorldPos.x / cellSize);
            y = Mathf.FloorToInt(WorldPos.y / cellSize);
        }

        public void SetValue(int x, int y, int value)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                gridArray[x, y].ID = value;
                debugTextMesh[x, y].text = gridArray[x, y].ID.ToString();
            }
        }

        public void SetValue(Vector3 WorldPos, int value)
        {
            int x, y;
            WorldToGrid(WorldPos, out x, out y);
            SetValue(x, y, value);
        }


        //Just for testing
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sonrtingOrder)
        {
            GameObject gameObject = new GameObject("World_text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.transform.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sonrtingOrder;
            return textMesh;
        }
    }
}
