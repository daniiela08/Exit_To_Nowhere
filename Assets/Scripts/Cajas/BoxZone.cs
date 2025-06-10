using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxZone : MonoBehaviour
{
    [SerializeField] private ItemObjectType acceptedType;
    [SerializeField] private EventManagerSO eventManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BoxItem>(out var puzzleObj))
        {
            if (puzzleObj.ItemType == acceptedType)
            {
                puzzleObj.OnPlaced();
            }
            else
            {
                // Puedes lanzar evento de error si quieres
                Debug.Log("Objeto incorrecto en esta caja.");
            }
        }
    }
}
