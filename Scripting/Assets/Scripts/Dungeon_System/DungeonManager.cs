using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

namespace Code_DungeonSystem
{
    public class DungeonManager : MonoBehaviour
    {
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
        
        public static DungeonManager Instance { get; private set; } = null;
        public Grid Grid { get => grid;}

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

        private void GenerateDungeon(int width, int height, float cellSize) 
        {
            grid = new Grid(width, height, cellSize);
            lastCell = grid.GetValue(width - 1, height - 1);
        }

        public Cell GetStartCell()
        {
            return grid.GetValue(0, 0);
        }
    }

    public class Grid: MonoBehaviour
    {
        private int width;
        private int height;
        private float cellSize;
        private Cell[,] gridArray;
        private TextMesh[,] debugTextMesh;
        private GameObject[,] cellPrefab;

        //[SerializeField] private DungeonManager dungeonManager = DungeonManager.Instance;
        //[SerializeField] private GameObject enemyPrefab = DungeonManager.Instance.enemyPrefab;

        public int GetWidth { get => width; }
        public int GetHeight { get => height; }

        public Grid(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            gridArray = new Cell[width, height];
            //debugTextMesh = new TextMesh[width, height]; //Visual
            //cellPrefab = new GameObject[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    gridArray[x, y] = Factory.Instance.CreateCell();
                    gridArray[x, y].CellConfig(this,x,y);
                }
            }

            //Visual
            /////////////////////////////////////////////////////////////////////
            /*int count = 0;
            for (int i = 0; i < gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridArray.GetLength(1); j++)
                {

                    debugTextMesh[i, j] = CreateWorldText(null, gridArray[i, j].ToString(), GridToWorld(i, j) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 5000);
                    cellPrefab[i, j] = new GameObject("Cell " + count);
                    SpriteRenderer spriteRenderer = cellPrefab[i, j].AddComponent<SpriteRenderer>();
                    spriteRenderer.sortingOrder = -10;
                    spriteRenderer.sprite = cellSprite;
                    spriteRenderer.color = Color.black;
                    cellPrefab[i, j].transform.localScale = new Vector3(cellSize, cellSize);
                    cellPrefab[i, j].transform.position = GridToWorld(i, j) + new Vector3(cellSize, cellSize) * .5f;
                    GenerateEnemy(enemyPrefab, cellPrefab[i,j].transform.position);
                    count++;
                }
            }*/
            //////////////////////////////////////////////////////////////////////
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

        public Cell GetValue(Vector3 WorldPos)
        {
            int x, y;
            WorldToGrid(WorldPos, out x, out y);
            return GetValue(x, y);
        }

        public void AdjustSize(GameObject obj) 
        {
            obj.transform.localScale = new Vector3(cellSize, cellSize);
        }

        public TextMesh GetText(int x, int y)
        {
            return debugTextMesh[x, y];
        }

        public SpriteRenderer GetCellRender(int x, int y)
        {
            return cellPrefab[x, y].GetComponent<SpriteRenderer>();
        }

        //Just for testing
        ///////////////////////////////////////////////////////////////////////////////////////////////
        /*public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sonrtingOrder)
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
        }*/
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /*public void GenerateEnemy(GameObject enemyPrefab, Vector3 cellPos)
        {
            Quaternion quaternion = new Quaternion(0, 0, 0, 0);
            cellPos = cellPos+new Vector3(4, -3, 0);
            GameObject prefabInstance = Instantiate(enemyPrefab, cellPos, quaternion);
        }*/
    }
}
