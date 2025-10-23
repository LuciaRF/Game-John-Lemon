using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int smothing;
    
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smothing);
    }
}
