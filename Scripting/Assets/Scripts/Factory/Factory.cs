using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Fabrica principal del proyecto 
/// Es la encargada de manejar todas las fabricas del proyecto y delegar sus funcionalidades
/// </summary>

public class Factory : MonoBehaviour 
{
    //Singletpn
    public static Factory Instance { get; private set; } = null; 

    //Fabrica de celdas
    private CellFactory _cellFactory;
    [SerializeField] private CellFactoryConfig _cellConfig;

    //Fabrica de equipamientos
    private EquimentFactory _equimentFactory;
    [SerializeField] private EquipmentFactoryConfig _equipmentConfig;

    private void Awake()
    {
        //Singleton
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        //Inicializacion de la configuracion y funcionamiento de las fabricas
        _cellConfig.SetUp();
        _cellFactory = new CellFactory(_cellConfig);
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
