using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaMetro : MonoBehaviour
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
            audioSource.enabled = true;
            yield return new WaitForSeconds(10f);
            audioSource.enabled = false;
            yield return new WaitForSeconds(22f);
        }
    }
}
