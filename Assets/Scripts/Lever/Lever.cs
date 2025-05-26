using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private int palancaID; // El índice en el orden correcto
    [SerializeField] private Animator animator;

    public static event Action<int> OnPalancaActivada;

    private bool activada = false;
    private bool isReseting = false;
    public void Interact()
    {
        if (activada) return; 

        activada = true;
        animator.SetTrigger("Activar");
        OnPalancaActivada?.Invoke(palancaID);
    }
    public void Resetear()
    {
        isReseting = true;
        activada = false;
        animator.SetTrigger("Resetear");

        // Desbloquea tras animación
        StartCoroutine(UnlockAferAnim());
    }

    private IEnumerator UnlockAferAnim()
    {
        yield return new WaitForSeconds(1f);
        isReseting = false;
    }
}
