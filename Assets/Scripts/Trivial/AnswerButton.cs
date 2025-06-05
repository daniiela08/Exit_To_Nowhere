using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour, IInteractable
{
    [SerializeField] private TrivialManager triviaManager;
    [SerializeField] private int answerIndex;

    [Header("-----Audio-----")]
    [SerializeField] AudioManager audioManager;
    public AudioClip[] sonidos;
    public void Interact()
    {
        audioManager.ReproducirSFX(sonidos[0]);
        triviaManager.SubmitAnswer(answerIndex);
    }
}
