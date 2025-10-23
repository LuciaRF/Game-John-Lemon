using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.isPlayerCaught = true;
        }
    }
}
