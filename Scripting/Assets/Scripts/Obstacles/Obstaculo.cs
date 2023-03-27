using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstaculo : MonoBehaviour
{
    [Header("Power")]
    int power;
    public int probabilidadMin = 1;     //Temporalmente públicos para revisar que valores llevan a una buena progresión
    public int probabilidadMax = 15;

    public Obstaculo(int power)
    {
        this.power = power;
    }

    void Start()
    {
        
    }

    public void GetPower()
    {
        power = Random.Range(probabilidadMin, probabilidadMax);
    }

    public int ScalePower(int power, int powerScale)
    {
        power = (power*powerScale);
        return power;
    }
}
