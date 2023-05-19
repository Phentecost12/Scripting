using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellFactory 
{
    private readonly CellFactoryConfig config;
    public CellFactory(CellFactoryConfig config) 
    {
        this.config = config;
    }

    public Cell Create() 
    {
        var cell = config.GetCellPrefab();
        return Object.Instantiate(cell);
    }
}
