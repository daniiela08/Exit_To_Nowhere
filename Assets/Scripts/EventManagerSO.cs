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
}
