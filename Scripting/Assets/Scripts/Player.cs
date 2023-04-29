using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class Player : MonoBehaviour, ICore
{
    readonly int PoderBase = 5;
    public int poderActual;
    public bool alive = true;
    readonly int VidaBase = 3;
    public int vidaActual;

    private Cell Startcell;
    private Cell currentCell;

    private Equipment[] equipmentEquiped = new Equipment[2];

    public Cell CurrentCell { get => currentCell; }

    public TextMesh txt;

    private void Awake()
    {
        poderActual = PoderBase;
        vidaActual = VidaBase;
        txt.text = poderActual.ToString();
        txt.color = Color.red;
    }

    private void Start()
    {
        Startcell = DungeonManager.Instance.GetStartCell();
    }

    public void RecalculatePower()
    {
        poderActual += equipmentEquiped[0].Power;

        if (equipmentEquiped[1] != null)
        {
            poderActual += equipmentEquiped[1].Power;
        }

        txt.text = poderActual.ToString();
    }

    public void Combat(Obstaculo Enemy)
    {
        int r = GetObstacleType(Enemy);

        switch (r)
        {
            case 1:
                SumarVida(1);
                Enemy.OnDying();
                break;

            case 2:

                if (equipmentEquiped[0] != null)
                {
                    Mago EnemyMage = (Mago)Enemy;

                    float BonusATK = 0;

                    switch (EnemyMage.Element)
                    {
                        case Elementos.Fire:

                            for (int i = 0; i < equipmentEquiped.Length - 1; i++)
                            {
                                if (equipmentEquiped[i]?.Element == Elementos.Water)
                                {
                                    BonusATK += 1.6f;
                                }
                            }

                            break;

                        case Elementos.Water:

                            for (int i = 0; i < equipmentEquiped.Length - 1; i++)
                            {
                                if (equipmentEquiped[i]?.Element == Elementos.Earth)
                                {
                                    BonusATK += 1.6f;
                                }
                            }

                            break;
                        case Elementos.Earth:

                            for (int i = 0; i < equipmentEquiped.Length - 1; i++)
                            {
                                if (equipmentEquiped[i]?.Element == Elementos.Fire)
                                {
                                    BonusATK += 1.6f;
                                }
                            }
                            break;
                    }

                    int ATK = (int)MathF.Round(poderActual * BonusATK);
                    Figth(ATK, EnemyMage);
                }
                else
                {
                    Figth(Enemy);
                }

                break;

            case 3:

                Chest chest = (Chest)Enemy;

                AddEquipment(chest.GeneratesAnEquipment());

                Enemy.OnDying();

                break;

            case 4:

                Figth(Enemy);

                break;
        }

        ;
    }

    public void AddEquipment(Equipment equipment)
    {

        if (equipmentEquiped[0] != null)
        {
            if (equipmentEquiped[1] == null)
            {
                equipmentEquiped[1] = equipment;
            }
            else
            {
                if (equipment.Power > equipmentEquiped[0].Power)
                {
                    equipmentEquiped[0] = equipment;
                }
                else if (equipment.Power > equipmentEquiped[1].Power)
                {
                    equipmentEquiped[1] = equipment;
                }
            }
        }
        else
        {
            equipmentEquiped[0] = equipment;
        }

        RecalculatePower();

    }

    public void Figth(Obstaculo enemy)
    {
        if (enemy.Power >= poderActual)
        {
            OnDying();
            enemy.OnWining(poderActual);
        }
        else
        {
            OnWining(enemy.Power);
            enemy.OnDying();
        }
    }

    public void Figth(int i, Obstaculo enemy)
    {
        if (i > poderActual)
        {
            OnDying();
            enemy.OnWining(poderActual);
        }
        else
        {
            OnWining(i);
            enemy.OnDying();
        }
    }

    private int GetObstacleType(Obstaculo P)
    {
        if (P is Angel)
        {
            return 1;
        }
        else if (P is Mago)
        {
            return 2;
        }
        else if (P is Chest)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }

    public void OnDying()
    {
        vidaActual--;
        if (vidaActual < 1)
            alive = false;
        currentCell = Startcell;
        transform.position = DungeonManager.Instance.Grid.GridToWorld(Startcell.X,Startcell.Y);
        Debug.Log(vidaActual);
    }

    public void OnWining(int suma)
    {
        poderActual += suma;
        txt.text = poderActual.ToString();
    }

    public void SumarVida(int cantidad)
    {
        vidaActual += cantidad;
        Debug.Log(vidaActual);
    }

    private Vector3 GetMousePosition() 
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePosition();
    }

    private void OnMouseUp()
    {
        Cell cell = DungeonManager.Instance.Grid.GetValue(transform.position);
        if ( cell.Enemy != null)
        {
            Debug.Log(cell.ToString());
            Combat(cell.Enemy);
        }
        else
        {
            Debug.Log("No hay enemigo");
        }
    }
}


