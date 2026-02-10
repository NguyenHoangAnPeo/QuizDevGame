using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubjectAbstract : AnMonoBehaviour
{
    [Header("Subject Abstract")]
    [SerializeField] protected SubjectCtrl subjectCtrl;
    [SerializeField] public SubjectCtrl SubjectCtrl => subjectCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubjCtrl();
    }
    protected virtual void LoadSubjCtrl()
    {
        if (this.subjectCtrl != null) return;
        this.subjectCtrl = transform.GetComponentInParent<SubjectCtrl>();
    }
}
