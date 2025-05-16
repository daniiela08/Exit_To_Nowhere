using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildZone : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !StairManager.Instance.isCompleted)
        {
            eventManager.EnterBuildArea();
        }

        if (other.TryGetComponent<StairStep>(out var stairStep))
        {
            stairStep.OnPlaced();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventManager.ExitBuildArea();
        }
    }
}
