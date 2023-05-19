using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code_DungeonSystem;

[CreateAssetMenu(menuName = "Configuration/CellFactory")]
public class CellFactoryConfig : ScriptableObject
{
    [SerializeField] private Cell[] cells;
    private Dictionary<int , Cell> cellDictionary;

    public void SetUp()
    {
        cellDictionary = new Dictionary<int , Cell>();

        for (int i = 0; i < cells.Length; i++)
        {
            cellDictionary.Add(i,cells[i]);
        }
    }

    public Cell GetCellPrefab() 
    {
       int i = Random.Range(0,100);

        if (i > 0 && i <= 5)
        {
            return cellDictionary[0];
        }

        if (i > 6 && i <= 25)
        {
            return cellDictionary[3];
        }

        if (i > 26 && i <= 40)
        {
            return cellDictionary[1];
        }

        return cellDictionary[2];
    }
}
