using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Equipment : MonoBehaviour
{
    Elementos element;
    public int power;

    public void SetUP()
    {
        int p = Random.Range(2, 6);
        this.power = p;

        int i = Random.Range(0, 3);

        element = (Elementos)Enum.ToObject(typeof(Elementos), i);
    }

    public Elementos Element { get => element; }
    public int Power { get => power; }
}
