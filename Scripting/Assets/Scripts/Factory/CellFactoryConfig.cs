using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code_DungeonSystem;

[CreateAssetMenu(menuName = "Configuration/CellFactory")]

//Configuracion de la fabrica de celdas
//Es un scriptableObject, una forma de estructura de datos personalizable que almacena variables
//y funcionalidades definidas por el programador dentro de un objeto instanciable dentro del proyecto. Se utiliza de esta forma
//para mayor versatilidad en caso tal de querer diferentes formas de crear los objetos. 

public class CellFactoryConfig : ScriptableObject
{
    //Prefabs que la fabrica crea
    [SerializeField] private Cell[] cells;
    private Dictionary<int , Cell> cellDictionary;

    //Inicializacion de la configuracion
    public void SetUp()
    {
        cellDictionary = new Dictionary<int , Cell>();

        for (int i = 0; i < cells.Length; i++)
        {
            cellDictionary.Add(i,cells[i]);
        }
    }

    //Se elige una celda de manera aleatoria
    // 0 = Celda de angel
    // 1 = Celda de cofre
    // 2 = Celda de mago 
    // 3 = Celda de Guardia
    public Cell GetCellPrefab() 
    {
       int i = Random.Range(0,100);

        if (i > 0 && i <= 5)
        {
            return cellDictionary[0];
        }

        if (i > 6 && i <= 25)
        {
            return cellDictionary[3];
        }

        if (i > 26 && i <= 40)
        {
            return cellDictionary[1];
        }

        return cellDictionary[2];
    }
}
