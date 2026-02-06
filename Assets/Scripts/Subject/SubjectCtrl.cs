using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectCtrl : AnMonoBehaviour
{
    [SerializeField] protected SubjectBtn subjectBtn;
    public SubjectBtn SubjectBtn => subjectBtn;

    [SerializeField] protected SubjectConfigSO subjectConfig;
    public SubjectConfigSO SubjectConfigSO => subjectConfig;

    [SerializeField] protected InitBtnData initBtnData;
    public InitBtnData InitBtnData => initBtnData;

    [SerializeField] protected string jsonName;
    public string JsonName => jsonName;

    public bool IsUnlock = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubjectBtn();
        this.LoadInitBtnData();
    }
    protected virtual void LoadInitBtnData()
    {
        if (this.initBtnData != null) return;
        this.initBtnData = transform.GetComponentInChildren<InitBtnData>();
    }
    protected virtual void LoadSubjectBtn()
    {
        if (this.subjectBtn != null) return;
        this.subjectBtn = transform.GetComponentInChildren<SubjectBtn>();
    }
    protected virtual void LoadJsonName()
    {
        if (this.subjectConfig == null) return;

        this.jsonName = subjectConfig.subjectName;
        Debug.Log("jsonName : " + jsonName);
    }
    public virtual void InitSubjectData(string configSOName)
    {
        if (this.subjectConfig != null) return;
        this.subjectConfig = Resources.Load<SubjectConfigSO>("SubjectConfig/" + configSOName);

        this.LoadJsonName();
        initBtnData.InitData(subjectConfig.displayName);
    }
}
