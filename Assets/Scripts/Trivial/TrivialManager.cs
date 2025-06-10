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

    [Header("-----Audio-----")]
    [SerializeField] AudioManager audioManager;
    public AudioClip[] sonidos;

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
            audioManager.ReproducirSFX(sonidos[0]);
            Debug.Log("Respuesta Correcta");
        }
        else
        {
            audioManager.ReproducirSFX(sonidos[1]);
            Debug.Log("Respuesta Incorrecta");
            mistakes++;
            CloseWalls();
        }

        currentQuestionIndex++;
        LoadQuestion();
    }

    private void CloseWalls()
    {
        Vector3 center = GetCenterPoint();

        // Mueve cada pared hacia el centro
        MoveWallTowards(wallLeft, center);
        MoveWallTowards(wallRight, center);
        MoveWallTowards(wallFront, center);
        MoveWallTowards(wallBack, center);

        // Verifica si ya están demasiado cerca
        float xDistance = Vector3.Distance(wallLeft.position, wallRight.position);
        float zDistance = Vector3.Distance(wallFront.position, wallBack.position);

        if (xDistance <= minDistanceBetweenWalls || zDistance <= minDistanceBetweenWalls)
        {
            Debug.Log("¡Has muerto! Las paredes se cerraron demasiado.");
            isActive = false;
        }
    }
    private Vector3 GetCenterPoint()
    {
        Vector3 total = wallLeft.position + wallRight.position + wallFront.position + wallBack.position;
        return total / 4f;
    }
    private void MoveWallTowards(Transform wall, Vector3 target)
    {
        Vector3 dir = (target - wall.position).normalized;
        wall.position += dir * wallMoveStep;
    }
    private void EndTrivia()
    {
        Debug.Log("Trivia completado");

        var uiDisplay = FindObjectOfType<UITrivialController>();
        if (uiDisplay != null)
        {
            uiDisplay.ShowFinalMessage();
        }

        teleportPortal.SetActive(true);
        isActive = false;
    }
}
