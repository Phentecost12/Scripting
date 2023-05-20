using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/EquipmentFactory")]
//Configuracion de la fabrica de equipamientos
//Es un scriptableObject, una forma de estructura de datos personalizable que almacena variables
//y funcionalidades definidas por el programador dentro de un objeto instanciable dentro del proyecto. Se utiliza de esta forma
//para mayor versatilidad en caso tal de querer diferentes formas de crear los objetos. 

public class EquipmentFactoryConfig : ScriptableObject
{
    //Prefabs que la fabrica va a crear
    [SerializeField] private Equipment[] equipments;
    private Dictionary<int, Equipment> equipmentDictionary;

    //Inicializacion de la configuracion
    public void SetUp()
    {
        equipmentDictionary = new Dictionary<int, Equipment>();

        for (int i = 0; i < equipments.Length; i++)
        {
            equipmentDictionary.Add(i, equipments[i]);
        }
    }

    //Se elige un equipamiento aleatorio
    public Equipment GetEquipmentPrefab()
    {
        int i = Random.Range(0, equipments.Length);
        return equipmentDictionary[i];
    }
}
