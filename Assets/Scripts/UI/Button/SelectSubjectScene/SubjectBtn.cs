using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubjectBtn : BaseBtn
{
    [SerializeField] protected SubjectCtrl subjectCtrl;
    public SubjectCtrl SubjectCtrl => subjectCtrl;

    [SerializeField] protected LastScoreText lastScoreText;
    public LastScoreText LastScoreText => lastScoreText;

    protected override void Start()
    {
        base.Start();
        if (QuizResultManager.Instance == null) return;
        int score = QuizResultManager.Instance.GetScore(subjectCtrl.JsonName);
        this.lastScoreText.TextMeshProUGUI.text = score.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubjectCtrl();
        this.LoadScoreText();
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
    protected virtual void SelectSubject()
    {
        QuizData.subject = subjectCtrl.JsonName;
        SceneManager.LoadScene("QuizScene");
    }
    protected override void OnClick()
    {
        Debug.Log("CLICK");

        if (this.subjectCtrl == null)
        {
            Debug.LogError("subjectCtrl NULL");
            return;
        }

        Debug.Log("subject json = " + subjectCtrl.JsonName);
        this.SelectSubject();
    }

}
