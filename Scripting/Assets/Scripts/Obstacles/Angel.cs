using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : Obstaculo
{
    //Player player = new Player(); //Missing player script
    public Angel(int poder, Cell cell) : base(poder, cell)
    {

    }

   /* public void sumarVida()
    {
        int currentHealth = player.vidaActual;

        player.vidaActual = currentHealth + 1;
    }*/
}
