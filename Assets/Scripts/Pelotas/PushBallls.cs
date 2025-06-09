using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBallls : MonoBehaviour
{
    [SerializeField] private float pushForce = 2.5f;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null && !rb.isKinematic && other.CompareTag("Bola"))
        {
            Vector3 direccion = other.transform.position - transform.position;
            direccion.y = 0;
            rb.AddForce(direccion.normalized * pushForce, ForceMode.VelocityChange);
        }
    }
}
