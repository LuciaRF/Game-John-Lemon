using System;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] Transform [] positions;
    [SerializeField] private float speed;
    [SerializeField] private GameManager gameManager;

    private Vector3 posToGo;
    private int i;

    private Ray ray;
    private RaycastHit hit;
    
    void Start()
    {
        i = 0;
        posToGo = positions[i].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangePosition();
        Rotate();
    }

    private void FixedUpdate()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        
        Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                gameManager.isPlayerCaught = true;
            }
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,posToGo,speed * Time.deltaTime);
    }

    void ChangePosition()
    {
        if (Vector3.Distance(transform.position, posToGo) <= Mathf.Epsilon)
        {
            if (i == positions.Length - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
            
            posToGo = positions[i].position;
        }
    }

    void Rotate()
    {
        transform.LookAt(posToGo);
    }
}
