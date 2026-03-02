using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBtnData : SubjectAbstract
{
    [SerializeField] protected SubjectBtn subjectBtn;
    public SubjectBtn SubjectBtn => subjectBtn;

    [SerializeField] protected int score;
    public int Score => score;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubjBtn();
    }
    protected virtual void LoadSubjBtn()
    {
        if (this.subjectBtn != null) return;
        this.subjectBtn = transform.GetComponent<SubjectBtn>();
    }
    public virtual void InitData(string nameSubjectDisplay,string nameSubjJson)
    {
        subjectBtn.SubjectName.TextMeshProUGUI.text = nameSubjectDisplay;

        this.score = SaveManager.Instance.GetScore(nameSubjJson);
        subjectBtn.LastScoreText.TextMeshProUGUI.text = score.ToString();
        //if (QuizResultManager.Instance == null) return;
        //this.score = QuizResultManager.Instance.GetScore(subjectBtn.SubjectCtrl.JsonName);
        //subjectBtn.LastScoreText.TextMeshProUGUI.text = score.ToString();
    }
}
