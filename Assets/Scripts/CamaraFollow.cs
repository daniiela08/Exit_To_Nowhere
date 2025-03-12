using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float rotationSpeed;
    void Update()
    {
        Vector3 direction = player.position - transform.position;

        // Rotaci�n suave hacia el jugador
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
