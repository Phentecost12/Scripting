using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PathFinding path = new PathFinding(10, 10);

        List<CellTesting> cells = path.FingPath(0, 0, 9, 9);

        foreach (CellTesting cell in cells) 
        {
            Debug.Log(cell.ToString());
        }
    }
}
