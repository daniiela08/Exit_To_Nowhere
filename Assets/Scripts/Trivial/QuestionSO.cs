using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea]
    public string questionText;

    public string[] options = new string[3];
    public int correctIndex;
}
