using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mago : Obstaculo
{
    private Elementos element;

    public override void SetUp()
    {
        base.SetUp();
        int i = Random.Range(0, 3);

        element = (Elementos)Enum.ToObject(typeof(Elementos), i);
    }

    public Elementos Element { get => element; }
}
