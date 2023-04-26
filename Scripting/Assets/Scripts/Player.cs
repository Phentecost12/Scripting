using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :ICore
{
    [SerializeField] int PoderBase = 5;
    public int poderActual;
    bool alive = true;
    [SerializeField] int VidaBase = 3;
    public int vidaActual;

    public Player() 
    {
        vidaActual = VidaBase;
        poderActual = PoderBase;
    }
    
    public void GetEquipment(int TypeE)
    {
        if (TypeE == 1)
            poderActual = poderActual * 2;
        else
            poderActual += TypeE;
    }

    public void comparePower(int enemyPwr)
    {
        if (enemyPwr > poderActual)
            cuandoMuere();
        else 
            cuandoGana(enemyPwr);
            
            
    }

    public void cuandoMuere()
    {
        vidaActual--;
        if (vidaActual < 1)
            alive = false;
        //volver a la casilla anterior.
    }

    public void cuandoGana(int suma)
    {
        poderActual += suma;
    }

}
