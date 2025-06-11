using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] puntosInicio;

    void Start()
    {
        int nivel = LevelSelector.LevelSelected;

        if (nivel <= 0 || nivel > puntosInicio.Length)
        {
            Debug.LogWarning("Nivel seleccionado fuera de rango: " + nivel);
            return;
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.LogError("No se encontró el jugador con tag 'Player'");
                return;
            }
        }

        Transform destino = puntosInicio[nivel - 1];

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        player.transform.position = destino.position;
        player.transform.rotation = destino.rotation;

        if (cc != null) cc.enabled = true;

        Debug.Log("Jugador colocado en nivel: " + nivel);
    }
}
