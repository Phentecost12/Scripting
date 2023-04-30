using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour
{
    private Vector3 offset = new Vector3(15f, 0f, -10f);
    [SerializeField]private float smoothTime = 5f;
    private Vector3 velocity = Vector3.zero;

    [Header("Camera Properties")]
    [SerializeField] private Transform target;
    [SerializeField] private DungeonManager dungeonManager;
    public  BoxCollider2D boundary;

    private float minX, maxX, minY, maxY;

    void Start()
    {
        minX = boundary.bounds.min.x; maxX = boundary.bounds.max.x;
        minY = boundary.bounds.min.y; maxY = boundary.bounds.max.y;
    }

    void Update()
    {
        ChangePos();
    }

    private void LateUpdate()
    {
        // Obtener la posición actual de la cámara
        Vector3 posicionCamara = transform.position;

        // Limitar el movimiento en el eje X
        posicionCamara.x = Mathf.Clamp(posicionCamara.x, minX, maxX);

        // Limitar el movimiento en el eje Y
        posicionCamara.y = Mathf.Clamp(posicionCamara.y, minY, maxY);

        // Asignar la nueva posición a la cámara
        transform.position = posicionCamara;
    }

    public void ChangePos()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    } 

    /*
    private void SetBoundary(Vector2 boundarySize)
    {   
        BoxCollider2D boundary = gameObject.AddComponent<BoxCollider2D>();

        boundary.size = boundarySize;
        boundary.offset = Vector2.zero;
    }
    */
}
