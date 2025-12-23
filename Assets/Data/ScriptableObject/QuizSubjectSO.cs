using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/Subject")]
public class QuizSubjectSO : ScriptableObject
{
    public string subjectName;
    public List<QuestionData> questions; //20 question
}
