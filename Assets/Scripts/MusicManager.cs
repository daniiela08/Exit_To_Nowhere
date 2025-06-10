using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource;
    public AudioClip[] musicClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int index)
    {
        if (index < 0 || index >= musicClips.Length)
        {
            Debug.LogWarning("Índice de música fuera de rango.");
            return;
        }

        if (audioSource.clip == musicClips[index] && audioSource.isPlaying)
            return;

        audioSource.clip = musicClips[index];
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
