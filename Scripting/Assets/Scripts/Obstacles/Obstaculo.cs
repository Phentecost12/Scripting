using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Elementos { Fire, Water, Earth }

public class Obstaculo
{
    int power;
    public int G;
    public int probabilidadMin = 1;
    public int probabilidadMax = 10;
    private Cell currentCell;

    public int Power { get => power; }

    public Obstaculo(int x, Cell cell)
    {
        G = GetPower();
        power = G * x + 1;

        this.currentCell = cell;
    }

    public int GetPower()
    {
        return Random.Range(probabilidadMin, probabilidadMax);
    }

    public void OnDying()
    {
        currentCell.ChangeText();
    }

    public void OnWining(int addingPower)
    {
        power += addingPower;
    }
}
