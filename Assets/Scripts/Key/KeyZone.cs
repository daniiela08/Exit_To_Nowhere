using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyZone : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<FirstPersonController>();

            if (player != null && !player.HasKeyInHand())
            {
                eventManager.KeyZoneEntered();
            }
        }

        if (other.TryGetComponent<KeyItem>(out var key))
        {
            key.OnPlaced(); // Enviar la llave al KeyManager
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventManager.KeyZoneExited();
        }
    }
}
