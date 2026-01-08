using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizUICtrl : AnMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI questionText;
    public TextMeshProUGUI QuestionText => questionText;
    [SerializeField] protected List<AnswerBtn> answerButtons = new();

    protected static QuizUICtrl instance;
    public static QuizUICtrl Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnsButtons();
    }
    protected override void Awake()
    {
        QuizUICtrl.instance = this;
    }
    protected virtual void LoadAnsButtons()
    {
        if (answerButtons.Count > 0) return;

        answerButtons = new List<AnswerBtn>(
            GetComponentsInChildren<AnswerBtn>(true)
        );
    }
    public void ShowQuestion(Question question)
    {
        questionText.text = question.question;

        for (int i = 0; i < answerButtons.Count; i++)
        {
            answerButtons[i].SetAnswerText(question.answers[i]);
            answerButtons[i].SetAnswerIndex(i);
        }
    }
}
