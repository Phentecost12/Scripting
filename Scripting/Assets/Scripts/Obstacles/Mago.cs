using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : Obstaculo
{
    int power;
    public Mago(int power) : base(power)
    {
        this.power = power;
    }

    enum Elementos {Fire, Water, Earth}
}
