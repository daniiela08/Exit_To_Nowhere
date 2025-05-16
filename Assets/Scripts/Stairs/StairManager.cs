using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairManager : MonoBehaviour
{
    public static StairManager Instance;

    [SerializeField] private Transform[] stepPositions; // Posiciones donde colocar cada escalón
    [SerializeField] private GameObject teleportToActivate;
    [SerializeField] private EventManagerSO eventManager;

    private int placedSteps = 0;
    private int totalSteps = 3;

    public bool isCompleted => placedSteps >= totalSteps;
    private void Awake()
    {
        Instance = this;
    }

    public void PlaceStep(StairStep step)
    {
        if (placedSteps >= totalSteps) return;

        // Parar movimiento físico
        Rigidbody rb = step.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Desactivar colisión si es necesario
        Collider col = step.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Colocar y ajustar
        step.transform.SetParent(stepPositions[placedSteps]);
        step.transform.localPosition = Vector3.zero;
        step.transform.localRotation = Quaternion.identity;
        step.transform.localScale = Vector3.one;
        step.SetPhysics(false);

        placedSteps++;

        if (placedSteps == totalSteps)
        {
            ActivateTeleport();
            eventManager.StaircaseBuilt();
        }
    }

    private void ActivateTeleport()
    {
        teleportToActivate.SetActive(true);
        Debug.Log("Teleport ACTIVADO: Escalera completada.");
    }
}
