using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquimentFactory
{
    private readonly EquipmentFactoryConfig config;

    public EquimentFactory(EquipmentFactoryConfig config) 
    {
        this.config = config;
    }

    public Equipment Create() 
    {
        var equi = config.GetEquipmentPrefab();
        return Object.Instantiate(equi);
    }
}
