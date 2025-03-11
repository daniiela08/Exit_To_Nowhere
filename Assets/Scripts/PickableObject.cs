using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour, IInteractable
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Interact()
    {
        FindObjectOfType<FirstPersonController>().PickObject(this);
    }
    public void SetPhysics(bool isActive)
    {
        rb.isKinematic = !isActive;
    }
}
