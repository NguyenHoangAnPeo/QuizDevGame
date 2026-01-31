using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectCtrl : AnMonoBehaviour
{
    [SerializeField] protected SubjectConfigSO subjectConfig;
    public SubjectConfigSO SubjectConfigSO => subjectConfig;

    [SerializeField] protected string jsonName;
    public string JsonName => jsonName;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubjectConfig();
    }
    protected virtual void LoadSubjectConfig()
    {
        if (this.subjectConfig != null) return;
        this.subjectConfig = Resources.Load<SubjectConfigSO>("SubjectConfig/"+transform.name);
        this.LoadJsonName();
    }
    protected virtual void LoadJsonName()
    {
        if (this.subjectConfig == null) return;

        this.jsonName = subjectConfig.subjectName;
        Debug.Log("jsonName : " + jsonName);
    }
}
