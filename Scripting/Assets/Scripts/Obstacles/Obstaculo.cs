using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//Elementos
public enum Elementos { Fire, Water, Earth }

public abstract class Obstaculo : MonoBehaviour
{
    
    int power;
    public int probabilidadMin = 1;
    public int probabilidadMax = 10;
    [SerializeField] private Cell currentCell;

    public int Power { get => power;}

    //Inicializacion del enemigo
    public virtual void SetUp() 
    {
        //Se toma un numero aleatorio dentro de un rango definido
        int G = GetPower();

        //Se aplica un factor escalar al poder
        power = G * currentCell.X + 1;
    }

    public int GetPower()
    {
        return Random.Range(probabilidadMin, probabilidadMax);
    }

    //Cuando pierde
    public void OnDying()
    {
        //Elimina el texto de la celda
        currentCell.ChangeText();
        //Se destruye
        Destroy(gameObject);
    }

    //Cuando gana
    public void OnWining(int addingPower)
    {
        //Se actualiza el poder del enemigo
        power += addingPower;
        currentCell.UpdateText();
    }
}
