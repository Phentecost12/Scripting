using Code_DungeonSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    //Referencia a la celda de inicio
    private Cell Startcell;

    //Referencia a la celda actuasl
    private Cell currentCell;

    //Equipamientos equipados
    public Equipment[] equipmentEquiped = new Equipment[2];

    public Cell CurrentCell { get => currentCell; }

    [SerializeField] private TextMesh txtPower;

    [SerializeField] private TextMesh txtLife;

    //Eventos a los que se suscriben los observadores
    public static event Action OnWiningEvents, OnDyingEvents;

    private void Awake()
    {
        poderActual = PoderBase;
        vidaActual = VidaBase;

        //Se configura el texto del poder
        txtPower.text = ToString();
        txtPower.color = Color.red;

        //Se configura el texto de la vida
        txtLife.text = vidaActual.ToString();
        txtLife.color = Color.blue;


    }


    private void Start()
    {
        //Se toma la referencia a la celda inicial 
        Startcell = DungeonManager.Instance.GetStartCell();
    }

    //Se suma el poder del equipamiento que se acaba de equipar 
    public void RecalculatePower(int i)
    {
        poderActual += equipmentEquiped[i].Power;
        txtPower.text = ToString();
    }

    //Se resta el poder del equipamiento que se acaba de quitar
    public void RemoveEquipment(int i) 
    {
        poderActual -= equipmentEquiped[i].Power;
    }

    public void Combat(Obstaculo Enemy)
    {
        //Se mira que tipo de enemigo esta en la celda
        // Angel = 1
        // Mago = 2
        // Cofre = 3
        // Guardia = 4

        int r = GetObstacleType(Enemy);

        switch (r)
        {
            case 1:

                SumarVida(1);
                OnWining(0);
                Enemy.OnDying();
                break;

            case 2:

                //Se mira si tiene algo equipado
                if (equipmentEquiped[0] != null)
                {
                    //Se hace un casteo al objeto apropiado
                    Mago EnemyMage = (Mago)Enemy;

                    //Bonus de ataque
                    float BonusATK = 1;

                    //Se mira el elemento del mago
                    switch (EnemyMage.Element)
                    {
                        case Elementos.Fire:

                            for (int i = 0; i < equipmentEquiped.Length - 1; i++)
                            {
                                //Se mira si posee algun equipamiento del elemento fuerte
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

                    //Se aplica el bonus al ataque del jugador
                    int ATK = (int)MathF.Round(poderActual * BonusATK);
                    Figth(ATK, EnemyMage);
                }
                else
                {
                    Figth(Enemy);
                }

                break;

            case 3:

                //Se hace el casteo al tipo de objeto apropiado
                Chest chest = (Chest)Enemy;

                //Se añade el equipamiento 
                AddEquipment(chest.GeneratesAnEquipment());

                OnWining(0);
                Enemy.OnDying();

                break;

            case 4:

                Figth(Enemy);

                break;
        }

        ;
    }

    //Logica de añadir equipamientos
    public void AddEquipment(Equipment equipment)
    {
        //Se inicializa el equipamiento
        equipment.SetUP();

        //Se mira si ya tenemos un equipamiento equipado
        if (equipmentEquiped[0] != null)
        {
            //Se mira si ya tenemos 2 equipamientos equipados
            if (equipmentEquiped[1] == null)
            {
                equipmentEquiped[1] = equipment;
                RecalculatePower(1);
            }
            else
            {
                //Se mira si el equipamiento nuevo tiene mas poder que el equipamiento viejo
                if (equipment.Power > equipmentEquiped[0].Power)
                {
                    //Se quita el poder del equipamiento
                    RemoveEquipment(0);

                    //Se agrega el equipamiento
                    equipmentEquiped[0] = equipment;

                    //Se suma el poder del nuevo equipamiento
                    RecalculatePower(0);
                }
                else if (equipment.Power > equipmentEquiped[1].Power)
                {
                    RemoveEquipment(1);
                    equipmentEquiped[1] = equipment;
                    RecalculatePower(1);
                    
                }
            }
        }
        else
        {
            equipmentEquiped[0] = equipment;
            RecalculatePower(0);
        }
    }

    //Sistema simple de combate
    public void Figth(Obstaculo enemy)
    {
        //Se mira si el poder del enemigo es mayor al del jugador
        if (enemy.Power >= poderActual)
        {
            //El jugador pierde
            OnDying();

            //El enemigo gana
            enemy.OnWining(poderActual);
        }
        else
        {
            //El jugador gana
            OnWining(enemy.Power);

            //El enemigo pierde
            enemy.OnDying();
        }
    }

    //Sobrecarga de la funcion (Para combatir al mago, se usa un bonus de poder)
    public void Figth(int i, Obstaculo enemy)
    {
        if (i < enemy.Power)
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

    //Funcion para obtener el tipo de enemigo
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

    //Cuando el jugador pierde
    public void OnDying()
    {
        //Se actualiza la vida
        vidaActual--;
        txtLife.text = vidaActual.ToString();

        //Si no tinee vida
        if (vidaActual < 1)
        {
            alive = false;

            //Se llama al evento correspondiente
            OnDyingEvents();
            return;
        } 

        //El jugador vuelve a la sala de inicio
        currentCell = Startcell;
        transform.position = DungeonManager.Instance.Grid.GridToWorld(Startcell.X,Startcell.Y);
        Debug.Log(vidaActual);
    }

    //Cuando el jugador gana
    public void OnWining(int suma)
    {
        //Se actualiza el poder
        poderActual += suma;
        txtPower.text = ToString();

        //Si la celda actual es la celda final
        if (currentCell == DungeonManager.Instance.lastCell)
        {
            //Se llama al evento correspondiente
            OnWiningEvents();
        }
    }

    //Suma una cantidad de vida al jugador
    public void SumarVida(int cantidad)
    {
        vidaActual += cantidad;
        txtLife.text = vidaActual.ToString();
        Debug.Log(vidaActual);
    }

    //Transforma coordenadas de pantalla a coordenadas de mundo
    private Vector3 GetMousePosition() 
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    //Cuando arrastro el mouse
    void OnMouseDrag()
    {
        if (alive)
        {
            //Muevo el jugador a la posicion del mouse
            transform.position = GetMousePosition();
        }
    }

    //Cuando suelto el mouse
    private void OnMouseUp()
    {
        //Miro en que celda cayo el jugador
        Cell cell = DungeonManager.Instance.Grid.GetValue(transform.position);
        if (cell != null)
        {
            //La celda actual se actualiza
            currentCell = cell;

            //Si la celda tiene un enemigo
            if (cell.Enemy != null)
            {
                Combat(cell.Enemy);
            }
            else
            {
                Debug.Log("No hay enemigo");
            }
        }
        else
        {
            Debug.Log("no hay celda");
        }
    }

    //Sobrecarga del funcion para facilitar el despliegue de textos
    public override string ToString()
    {
        string r;
        r = poderActual.ToString();
        r += " \n";
        r += equipmentEquiped[0] ? equipmentEquiped[0].Element : "";
        r += " \n";
        r += equipmentEquiped[1] ? equipmentEquiped[1].Element : "";
        return r;
    }
}


