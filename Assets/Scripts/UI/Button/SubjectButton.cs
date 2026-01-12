using UnityEngine;

public class SubjectButton : MonoBehaviour
{
    [SerializeField] private string subjectKey;

    public void OnClick()
    {
        QuizManager.Instance.StartQuiz(subjectKey);
    }
}
