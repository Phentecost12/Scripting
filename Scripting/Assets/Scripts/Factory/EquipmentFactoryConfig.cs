using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/EquipmentFactory")]
public class EquipmentFactoryConfig : ScriptableObject
{
    [SerializeField] private Equipment[] equipments;
    private Dictionary<int, Equipment> equipmentDictionary;

    public void SetUp()
    {
        equipmentDictionary = new Dictionary<int, Equipment>();

        for (int i = 0; i < equipments.Length; i++)
        {
            equipmentDictionary.Add(i, equipments[i]);
        }
    }

    public Equipment GetEquipmentPrefab()
    {
        int i = Random.Range(0, equipments.Length);
        return equipmentDictionary[i];
    }
}
