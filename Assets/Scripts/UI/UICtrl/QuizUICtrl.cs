using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizUICtrl : AnMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI questionText;
    public TextMeshProUGUI QuestionText => questionText;
    [SerializeField] protected List<AnswerBtn> answerButtons = new();

    [SerializeField] protected float questionAnimDuration = 0.16f;

    protected static QuizUICtrl instance;
    public static QuizUICtrl Instance => instance;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (GameStateManager.Instance == null) return;
        GameStateManager.Instance.OnStateChanged += HandleStateChanged;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (GameStateManager.Instance == null) return;
        GameStateManager.Instance.OnStateChanged -= HandleStateChanged;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnsButtons();
    }
    protected override void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
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
            UIAnimationUtil.ScaleIn(this, answerButtons[i].transform, questionAnimDuration);
        }

        if (questionText != null)
        {
            UIAnimationUtil.ScaleIn(this, questionText.transform, questionAnimDuration);
        }
    }

    public void SetAnswerButtonsInteractable(bool value)
    {
        this.SetBtn(value);
    }
    protected virtual void HandleStateChanged(GameState oldState,GameState newState)
    {
        bool canSetBtn = newState == GameState.PlayingQuiz;
        this.SetBtn(canSetBtn);
    }
    protected virtual void SetBtn(bool value)
    {
        foreach (var btn in answerButtons)
        {
            btn.SetInteractable(value);
        }
    }
    public IEnumerator ClickAnswer(Button button, RectTransform rectTransform)
    {
        button.interactable = false;

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
        button.interactable = true;
    }
}
