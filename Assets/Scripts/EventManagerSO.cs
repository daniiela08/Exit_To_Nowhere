using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Event Manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNewInteractable;
    public event Action OnNoInteractable;

    public Action<SubtitleDataSO.SubtitleEntry> OnSubtitleTriggered;

    public event Action OnBuildAreaEntered;
    public event Action OnBuildAreaExited;
    public event Action OnStaircaseBuilt;

    public event Action OnKeyZoneEntered;
    public event Action OnKeyZoneExited;
    public event Action OnKeyInserted;
    public void NewInteractable()
    {
        OnNewInteractable?.Invoke();
    }
    public void NoInteractable()
    {
        OnNoInteractable?.Invoke();
    }
    public void TriggerSubtitle(SubtitleDataSO.SubtitleEntry subtitleData)
    {
        OnSubtitleTriggered?.Invoke(subtitleData);
    }

    public void EnterBuildArea() => OnBuildAreaEntered?.Invoke();
    public void ExitBuildArea() => OnBuildAreaExited?.Invoke();
    public void StaircaseBuilt() => OnStaircaseBuilt?.Invoke();

    public void KeyZoneEntered() => OnKeyZoneEntered?.Invoke();
    public void KeyZoneExited() => OnKeyZoneExited?.Invoke();
    public void KeyInserted() => OnKeyInserted?.Invoke();
}
