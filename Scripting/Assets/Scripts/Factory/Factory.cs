using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Factory : MonoBehaviour 
{
    public static Factory Instance { get; private set; } = null; 

    private CellFactory _cellFactory;
    [SerializeField] private CellFactoryConfig _cellConfig;

    private ObstacleFactory _obstacleFactory;
    [SerializeField] private ObstacleFactoryConfig _obstacleConfig;

    private EquimentFactory _equimentFactory;
    [SerializeField] private EquipmentFactoryConfig _equipmentConfig;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        _cellConfig.SetUp();
        _cellFactory = new CellFactory(_cellConfig);
        _obstacleFactory = new ObstacleFactory(_obstacleConfig);
        _equipmentConfig.SetUp();
        _equimentFactory = new EquimentFactory(_equipmentConfig);

    }

    public Cell CreateCell() 
    {
        return _cellFactory.Create();
    }

    public Equipment CreateEquipment() 
    {
        return _equimentFactory.Create();
    }

}
