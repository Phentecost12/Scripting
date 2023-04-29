using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Obstaculo
{
    public Chest(int power, Cell cell) : base(power, cell)
    {

    }

    public Equipment GeneratesAnEquipment()
    {
        return new Equipment((int)MathF.Floor(base.Power / 2));
    }
}
