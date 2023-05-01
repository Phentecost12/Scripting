using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Lose_Manager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;
    public static Win_Lose_Manager Intance { get; private set; } = null;
    private void Awake()
    {
        if (Intance != null)
        {
            Destroy(this);
            return;
        }

        Intance = this;

        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void Lose() 
    {
        losePanel.SetActive(true);
    }

    public void Win() 
    {
        winPanel.SetActive(true);
    }
}