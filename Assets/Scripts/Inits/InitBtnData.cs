using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBtnData : AnMonoBehaviour
{
    [SerializeField] protected SubjectBtn subjectBtn;
    public SubjectBtn SubjectBtn => subjectBtn;
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
    public virtual void InitData(string nameSubject)
    {
        subjectBtn.SubjectName.TextMeshProUGUI.text = nameSubject;

        if (QuizResultManager.Instance == null) return;
        int score = QuizResultManager.Instance.GetScore(subjectBtn.SubjectCtrl.JsonName);
        subjectBtn.LastScoreText.TextMeshProUGUI.text = score.ToString();
    }
}
