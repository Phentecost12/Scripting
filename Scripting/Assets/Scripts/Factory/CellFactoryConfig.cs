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
       int i = Random.Range(0,cells.Length);
        return cellDictionary[i];
    }
}
