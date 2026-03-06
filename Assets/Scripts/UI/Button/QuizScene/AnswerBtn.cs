using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class AnswerBtn : BaseBtn
{
    [SerializeField] protected TextMeshProUGUI answerText;
    public TextMeshProUGUI AnswerText => answerText;

    [SerializeField] protected int answerIndex;
    public int AnswerIndex => answerIndex;

    [SerializeField] protected RectTransform rectTransform;

    [SerializeField] protected QuizUICtrl quizUICtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnswerText();
        this.LoadQuizUICtrl();
    }
    protected virtual void LoadQuizUICtrl()
    {
        if (this.quizUICtrl != null) return;
        this.quizUICtrl = transform.GetComponentInParent<QuizUICtrl>();
    }
    protected virtual void LoadRect()
    {
        if (this.rectTransform != null) return;
        this.rectTransform = transform.GetComponent<RectTransform>();
    }
    protected virtual void LoadAnswerText()
    {
        if (this.answerText != null) return;
        this.answerText = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected override void OnClick()
    {
        StartCoroutine(this.quizUICtrl.ClickAnswer(button,rectTransform));
        QuizManager.Instance.CheckAnswer(answerIndex);
    }
    public virtual void SetAnswerText(string text)
    {
        this.answerText.text = text;
    }
    public virtual void SetAnswerIndex(int index)
    {
        this.answerIndex = index;
    }
    public void SetInteractable(bool value)
    {
        button.interactable = value;
    }
}
