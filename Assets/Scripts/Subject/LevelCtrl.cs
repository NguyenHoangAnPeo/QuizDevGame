using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtrl : AnMonoBehaviour
{
    [SerializeField] protected List<SubjectCtrl> subjectList = new();
    public List<SubjectCtrl> SubjectList => subjectList;
    [SerializeField] protected int currentMaxLevel = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubject();
    }
    protected virtual void LoadSubject()
    {
        if (this.subjectList.Count > 0) return;
        subjectList = new List<SubjectCtrl>(GetComponentsInChildren<SubjectCtrl>(true));
    }
}
