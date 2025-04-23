using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private Image panel;
    [SerializeField] private float fadeDuration;

    private bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting && other.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine(other.transform));
        }
    }
    private IEnumerator TeleportRoutine(Transform player)
    {
        isTeleporting = true;

        yield return StartCoroutine(Fade(1));

        // Desactivar momentáneamente CharacterController
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller) controller.enabled = false;

        player.position = teleportTarget.position;

        if (controller) controller.enabled = true;

        yield return StartCoroutine(Fade(0));

        isTeleporting = false;
    }
    private IEnumerator Fade(float targetAlpha)
    {
        float t = 0;
        Color originalColor = panel.color;
        float startAlpha = originalColor.a;
        Color newColor = originalColor;

        while(t < fadeDuration)
        {
            t += Time.deltaTime;
            float blend = Mathf.Clamp01(t / fadeDuration);
            newColor.a = Mathf.Lerp(startAlpha, targetAlpha, blend);
            panel.color = newColor;
            yield return null;
        }
        newColor.a = targetAlpha;
        panel.color = newColor;
    }
}
