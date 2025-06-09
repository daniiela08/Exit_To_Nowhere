using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [Header("Prefabs de bolas (4 tipos)")]
    [SerializeField] private GameObject[] prefabsBolas;

    [Header("Zona de generación (tamaño del contenedor)")]
    [SerializeField] private Vector3 centroPiscina = Vector3.zero;
    public Vector3 tamañoPiscina = new Vector3(5f, 2f, 5f);

    [Header("Parámetros")]
    [SerializeField] private int cantidadBolas = 200;
    [SerializeField] private float separacionMinima = 0.3f; // para evitar solapamientos

    private int intentosMaximos = 5000;

    void Start()
    {
        GenerarBolas();
    }

    void GenerarBolas()
    {
        int generadas = 0;
        int intentos = 0;

        while (generadas < cantidadBolas && intentos < intentosMaximos)
        {
            intentos++;

            // Posición aleatoria dentro del volumen definido
            Vector3 posicion = new Vector3(
                Random.Range(-tamañoPiscina.x / 2, tamañoPiscina.x / 2),
                Random.Range(0, tamañoPiscina.y),
                Random.Range(-tamañoPiscina.z / 2, tamañoPiscina.z / 2)
            ) + centroPiscina;

            // Asegurar que no se solapan (opcional, puede ser costoso si son muchas)
            if (Physics.CheckSphere(posicion, separacionMinima)) continue;

            // Elegir prefab aleatorio
            GameObject prefab = prefabsBolas[Random.Range(0, prefabsBolas.Length)];

            // Instanciar
            Instantiate(prefab, posicion, Random.rotation);
            generadas++;
        }

        Debug.Log($"Bolas generadas: {generadas} / {cantidadBolas}");
    }

    // Visual en editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 1, 0.25f);
        Gizmos.DrawCube(centroPiscina, tamañoPiscina);
    }
}
