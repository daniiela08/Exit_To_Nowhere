using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemObjectType
{
    Cone,
    Sphere,
    Cube
}
public class BoxItem : PickableObject
{
    [SerializeField] private ItemObjectType itemType;

    public ItemObjectType ItemType => itemType;

    public void OnPlaced()
    {
        BoxManager.Instance.RegisterObject(itemType);
        Destroy(gameObject);
    }
}
