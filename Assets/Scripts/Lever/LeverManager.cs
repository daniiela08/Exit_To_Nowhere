using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    [SerializeField] private int[] correctSecuence;
    [SerializeField] private List<Lever> levers; // Asigna desde el editor
    private List<int> ordenActual = new List<int>();

    [SerializeField] private GameObject tp;

    private bool isReseting = false;

    private void OnEnable()
    {
        Lever.OnPalancaActivada += ValidateLever;
    }

    private void OnDisable()
    {
        Lever.OnPalancaActivada -= ValidateLever;
    }

    private void ValidateLever(int id)
    {
        if (isReseting)
            return;

        ordenActual.Add(id);

        int index = ordenActual.Count - 1;
        if (correctSecuence[index] != id)
        {
            isReseting = true;
            StartCoroutine(ResetCourutine());
            return;
        }

        if (ordenActual.Count == correctSecuence.Length)
        {
            ActivateTP();
        }
    }
    private void ResetPuzzle()
    {
        ordenActual.Clear();

        foreach (var palanca in levers)
        {
            palanca.Resetear();
        }
        StartCoroutine(FinDeReset());
    }
    private void ActivateTP()
    {
        tp.SetActive(true);
    }
    private IEnumerator ResetCourutine()
    {
        yield return new WaitForSeconds(1f); // Esperar a que la animación "incorrecta" se vea
        ResetPuzzle();
    }
    private IEnumerator FinDeReset()
    {
        yield return new WaitForSeconds(1f); // Duración de reset de animaciones
        isReseting = false;
    }
}
