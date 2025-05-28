using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrivialManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private QuestionSetSO questionSet;

    [Header("Walls")]
    [SerializeField] private Transform wallLeft;
    [SerializeField] private Transform wallRight;
    [SerializeField] private Transform wallFront;
    [SerializeField] private Transform wallBack;

    [SerializeField] private float wallMoveStep = 0.5f;
    [SerializeField] private float minDistanceBetweenWalls = 1f;

    [Header("Events & UI")]
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private GameObject teleportPortal;

    public static Action<QuestionSO> OnQuestionLoaded;

    private int currentQuestionIndex = 0;
    private int mistakes = 0;
    private bool isActive = true;

    public void StartTrivia()
    {
        currentQuestionIndex = 0;
        mistakes = 0;
        isActive = true;
        teleportPortal.SetActive(false);
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        if (currentQuestionIndex >= questionSet.questions.Count)
        {
            EndTrivia();
            return;
        }

        QuestionSO question = questionSet.questions[currentQuestionIndex];

        OnQuestionLoaded?.Invoke(question);
    }

    public void SubmitAnswer(int answerIndex)
    {
        if (!isActive) return;

        QuestionSO current = questionSet.questions[currentQuestionIndex];
        if (answerIndex == current.correctIndex)
        {
            Debug.Log("Respuesta Correcta");
        }
        else
        {
            Debug.Log("Respuesta Incorrecta");
            mistakes++;
            CloseWalls();
        }

        currentQuestionIndex++;
        LoadQuestion();
    }

    private void CloseWalls()
    {
        wallLeft.position += Vector3.right * wallMoveStep;
        wallRight.position += Vector3.left * wallMoveStep;
        wallFront.position += Vector3.back * wallMoveStep;
        wallBack.position += Vector3.forward * wallMoveStep;

        // Verifica si ya están demasiado cerca
        float xDistance = Vector3.Distance(wallLeft.position, wallRight.position);
        float zDistance = Vector3.Distance(wallFront.position, wallBack.position);

        if (xDistance <= minDistanceBetweenWalls || zDistance <= minDistanceBetweenWalls)
        {
            Debug.Log("¡Has muerto! Las paredes se cerraron demasiado.");
            isActive = false;
            // Aquí puedes emitir un evento de GameOver o reiniciar la escena
        }
    }

    private void EndTrivia()
    {
        Debug.Log("Trivia completado");
        teleportPortal.SetActive(true);
    }
}
