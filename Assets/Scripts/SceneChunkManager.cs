using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChunkManager : MonoBehaviour
{
    [SerializeField] private GameObject[] escenarios;

    // Mantén activos los escenarios actuales y el siguiente
    public void ActivarEscenarioVentana(int escenarioActual)
    {
        for (int i = 0; i < escenarios.Length; i++)
        {
            if (i == escenarioActual || i == escenarioActual + 1)
                escenarios[i].SetActive(true);
            else
                escenarios[i].SetActive(false);
        }
    }
}
