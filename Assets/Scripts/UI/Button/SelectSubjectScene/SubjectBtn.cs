using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubjectBtn : BaseBtn
{
    [SerializeField] protected float sceneLoadDelay = 0.12f;

    [SerializeField] protected SubjectCtrl subjectCtrl;
    public SubjectCtrl SubjectCtrl => subjectCtrl;

    [SerializeField] protected LastScoreText lastScoreText;
    public LastScoreText LastScoreText => lastScoreText;

    [SerializeField] protected SubjectName subjectName;
    public SubjectName SubjectName => subjectName;

    protected bool isHandlingClick;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubjectCtrl();
        this.LoadScoreText();
        this.LoadSubjectName();
    }
    protected virtual void LoadSubjectCtrl()
    {
        if (this.subjectCtrl != null) return;
        this.subjectCtrl = transform.GetComponentInParent<SubjectCtrl>();
    }
    protected virtual void LoadScoreText()
    {
        if (this.lastScoreText != null) return;
        this.lastScoreText = transform.GetComponentInChildren<LastScoreText>();
    }
    protected virtual void LoadSubjectName()
    {
        if (this.subjectName != null) return;
        this.subjectName = transform.GetComponentInChildren<SubjectName>();
    }
    protected virtual void SelectSubject()
    {
        QuizData.subjectName = subjectCtrl.JsonName;
        StartCoroutine(StartQuiz());
    }
    protected override void OnClick()
    {
        if (this.subjectCtrl == null) return;

        this.SelectSubject();
    }

    protected override void HandleClick()
    {
        if (isHandlingClick) return;
        StartCoroutine(this.CoHandleSceneClick());
    }

    protected virtual IEnumerator CoHandleSceneClick()
    {
        isHandlingClick = true;

        if (button != null) button.interactable = false;
        yield return this.CoHandleClickWithDelay(sceneLoadDelay);

        if (button != null) button.interactable = true;
        isHandlingClick = false;
    }
    public void SetInteractable(bool value)
    {
        button.interactable = value;
    }
    IEnumerator StartQuiz()
    {
        GameManager.Instance.EndTransitionScene();

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("QuizScene");
    }
}
