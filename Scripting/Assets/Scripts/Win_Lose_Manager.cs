using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Lose_Manager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;

    //Singleton
    public static Win_Lose_Manager Intance { get; private set; } = null;
    
    private void Awake()
    {
        //Singleton
        if (Intance != null)
        {
            Destroy(this);
            return;
        }

        Intance = this;

        //Se suscribe al sujeto
        Player.OnWiningEvents += Win;
        Player.OnDyingEvents += Lose;

        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        //Se desuscribe del sujeto
        Player.OnWiningEvents -= Win;
        Player.OnDyingEvents -= Lose;
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
