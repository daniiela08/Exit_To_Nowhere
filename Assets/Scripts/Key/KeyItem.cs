using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : PickableObject
{
    public void OnPlaced()
    {
        KeyManager.Instance.InsertKey(this);
    }
}
