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
        StartCoroutine(ClickRoutine());
    //QuizManager.Instance.CheckAnswer(answerIndex);
    }
    private IEnumerator ClickRoutine()
    {
        SetInteractable(false);

        Vector3 originalScale = rectTransform.localScale;
        Vector3 pressedScale = originalScale * 0.9f;

        yield return UITransitionService.Instance.ScalePop(
            rectTransform,
            originalScale,
            pressedScale,
            0.2f
        );

        yield return UITransitionService.Instance.ScalePop(
            rectTransform,
            pressedScale,
            originalScale,
            0.2f
        );

        QuizManager.Instance.CheckAnswer(answerIndex);
        SetInteractable(true);
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
