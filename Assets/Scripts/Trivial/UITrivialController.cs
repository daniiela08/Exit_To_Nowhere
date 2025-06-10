using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITrivialController : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text[] answerTexts; // 3 textos (uno por opción)

    private void OnEnable()
    {
        TrivialManager.OnQuestionLoaded += UpdateDisplay;
    }

    private void OnDisable()
    {
        TrivialManager.OnQuestionLoaded -= UpdateDisplay;
    }

    private void UpdateDisplay(QuestionSO question)
    {
        questionText.text = question.questionText;
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = question.options[i];
        }
    }
    public void ShowFinalMessage()
    {
        questionText.text = "Enhorabuena!, dirígete hacia aquí";
        foreach (var txt in answerTexts)
        {
            txt.text = "UP"; 
        }
    }
}
