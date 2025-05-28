using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour, IInteractable
{
    [SerializeField] private TrivialManager triviaManager;
    [SerializeField] private int answerIndex; 

    public void Interact()
    {
        triviaManager.SubmitAnswer(answerIndex);
    }
}
