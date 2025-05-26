using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairStep : PickableObject, IBuild, IInteractable
{
    public void OnPlaced()
    {
        StairManager.Instance.PlaceStep(this);
    }
}
