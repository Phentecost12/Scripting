using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstaculo
{
    [Header("Power")]
    int power;
    public int probabilidadMin = 1;     //Temporalmente públicos para revisar que valores llevan a una buena progresión
    public int probabilidadMax = 10;

    public int Power { get => power;}

    public Obstaculo(int x)
    {
        int G = GetPower();
        power = G * x + 1;
    }

    public int GetPower()
    {
        return Random.Range(probabilidadMin, probabilidadMax);
    }

    public int ScalePower(int power, int powerScale)
    {
        power = (power*powerScale);
        return power;
    }
}
