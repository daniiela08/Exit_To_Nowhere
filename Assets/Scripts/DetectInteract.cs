using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectInteract : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;
    [SerializeField]
    private RawImage fillCircle;

    private void OnEnable()
    {
        eventManager.OnNewInteractable += CircleOn;
        eventManager.OnNoInteractable += CircleOff;
    }
    private void OnDisable()
    {
        eventManager.OnNewInteractable -= CircleOn;
        eventManager.OnNoInteractable -= CircleOff;
    }
    private void CircleOn()
    {
        fillCircle.enabled = true;
    }
    private void CircleOff()
    {
        fillCircle.enabled = false;
    }
}
