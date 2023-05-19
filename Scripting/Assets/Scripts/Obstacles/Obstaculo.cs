using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Elementos { Fire, Water, Earth }

public abstract class Obstaculo : MonoBehaviour
{
    int power;
    private int G;
    public int probabilidadMin = 1;
    public int probabilidadMax = 10;
    [SerializeField] private Cell currentCell;

    public int Power { get => power; }

    public virtual void SetUp() 
    {
        G = GetPower();
        power = G * currentCell.X + 1;
    }

    public int GetPower()
    {
        return Random.Range(probabilidadMin, probabilidadMax);
    }

    public void OnDying()
    {
        currentCell.ChangeText();
        Destroy(gameObject);
    }

    public void OnWining(int addingPower)
    {
        power += addingPower;
    }
}
