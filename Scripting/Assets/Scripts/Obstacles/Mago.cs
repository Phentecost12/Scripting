using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mago : Obstaculo
{
    private Elementos element;

    public Mago(int power , Cell cell) : base(power, cell)
    {
        

        int i = Random.Range(0, 3);

        element = (Elementos)Enum.ToObject(typeof(Elementos), i);
    }

    public Elementos Element { get => element; }
}
