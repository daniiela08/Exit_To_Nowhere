using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public static BoxManager Instance;

    [SerializeField] private GameObject teleportToActivate;
    [SerializeField] private EventManagerSO eventManager;

    private HashSet<ItemObjectType> deliveredObjects = new();

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterObject(ItemObjectType type)
    {
        if (deliveredObjects.Contains(type)) return;

        deliveredObjects.Add(type);
        Debug.Log($"{type} entregado correctamente.");

        if (deliveredObjects.Count == 3)
        {
            teleportToActivate.SetActive(true);
        }
    }
}
