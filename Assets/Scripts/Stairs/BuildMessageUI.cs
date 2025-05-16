using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMessageUI : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private EventManagerSO eventManager;

    private void OnEnable()
    {
        eventManager.OnBuildAreaEntered += ShowMessage;
        eventManager.OnBuildAreaExited += HideMessage;
        eventManager.OnStaircaseBuilt += HideMessage;
    }
    private void OnDisable()
    {
        eventManager.OnBuildAreaEntered -= ShowMessage;
        eventManager.OnBuildAreaExited -= HideMessage;
        eventManager.OnStaircaseBuilt -= HideMessage;
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
