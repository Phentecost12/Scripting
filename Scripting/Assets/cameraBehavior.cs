using Code_DungeonSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour
{
    private Vector3 offset = new Vector3(15f, 0f, -10f);
    [SerializeField]private float smoothTime = 5f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    void Update()
    {
        ChangePos();
    }

    public void ChangePos()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    } 
}
