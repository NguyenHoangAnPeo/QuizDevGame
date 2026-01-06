using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerBtn : BaseBtn
{
    [SerializeField] protected TextMeshProUGUI answerText;
    [SerializeField] protected int answerIndex;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnswerText();
    }
    protected virtual void LoadAnswerText()
    {
        if (this.answerText != null) return;
        this.answerText = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected override void OnClick()
    {
        throw new System.NotImplementedException();
    }
    public virtual void SetAnswerText(string text)
    {
        this.answerText.text = text;
    }
    public virtual void SetAnswerIndex(int index)
    {
        this.answerIndex = index;
    }
}
