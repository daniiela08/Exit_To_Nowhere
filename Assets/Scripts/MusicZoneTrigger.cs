using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZoneTrigger : MonoBehaviour
{
    [SerializeField] private int musicIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.Instance.PlayMusic(musicIndex);
        }
    }
}
