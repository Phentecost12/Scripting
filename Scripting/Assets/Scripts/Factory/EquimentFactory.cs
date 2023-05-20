using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquimentFactory
{
    private readonly EquipmentFactoryConfig config;

    //Constructor de la fabrica (Se le inyecta la configuracion)
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
