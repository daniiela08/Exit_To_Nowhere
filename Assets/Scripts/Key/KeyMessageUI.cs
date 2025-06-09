using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMessageUI : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private EventManagerSO eventManager;

    private void OnEnable()
    {
        eventManager.OnKeyZoneEntered += ShowMessage;
        eventManager.OnKeyZoneExited += HideMessage;
        eventManager.OnKeyInserted += HideMessage;
    }

    private void OnDisable()
    {
        eventManager.OnKeyZoneEntered -= ShowMessage;
        eventManager.OnKeyZoneExited -= HideMessage;
        eventManager.OnKeyInserted -= HideMessage;
    }

    private void ShowMessage()
    {
        messagePanel.SetActive(true);
    }

    private void HideMessage()
    {
        messagePanel.SetActive(false);
    }
}
