using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance;

    [SerializeField] private GameObject teleportToActivate;
    [SerializeField] private EventManagerSO eventManager;

    private bool keyInserted = false;

    private void Awake()
    {
        Instance = this;
    }
    public void InsertKey(KeyItem key)
    {
        if (keyInserted) return;

        keyInserted = true;

        // Desactivar física antes de destruir
        Rigidbody rb = key.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        Destroy(key.gameObject);

        teleportToActivate.SetActive(true);

        eventManager?.KeyInserted();

        Debug.Log("Llave insertada (destruida). Teleport activado.");
    }
}
