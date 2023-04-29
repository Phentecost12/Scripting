using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;
using Random = UnityEngine.Random;

public class Equipment
{
    Elementos element;
    int power;

    public Equipment(int power)
    {
        this.power = power;

        int i = Random.Range(0, 3);

        element = (Elementos)Enum.ToObject(typeof(Elementos), i);
    }

    public Elementos Element { get => element; }
    public int Power { get => power; }
}
