using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question Set")]
public class QuestionSetSO : ScriptableObject
{
    public List<QuestionSO> questions;
}
