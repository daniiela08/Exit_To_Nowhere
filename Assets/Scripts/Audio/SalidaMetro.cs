using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalidaMetro : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Sonido());
    }
    private IEnumerator Sonido()
    {
        while (true)
        {
            audioSource.enabled = false;
            yield return new WaitForSeconds(25f);
            audioSource.enabled = true;
            yield return new WaitForSeconds(6f);
        }
    }
}
