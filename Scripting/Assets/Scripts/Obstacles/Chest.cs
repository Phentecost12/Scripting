using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Obstaculo
{
    public Equipment GeneratesAnEquipment()
    {
        return Factory.Instance.CreateEquipment();
    }
}
