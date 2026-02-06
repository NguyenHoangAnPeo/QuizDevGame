using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorUICtrl : AnMonoBehaviour
{
    [SerializeField] protected MajorSO majorSO;
    public MajorSO MajorSO => majorSO;

    [SerializeField] protected MajorName majorName;
    public MajorName MajorName => majorName;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMajorSO();
        this.LoadMajorName();
    }
    protected virtual void LoadMajorSO()
    {
        if (this.majorSO != null) return;
        this.majorSO = Resources.Load<MajorSO>("MajorSO/" + transform.name);
    }
    protected virtual void LoadMajorName()
    {
        if (this.majorName != null) return;
        this.majorName = transform.GetComponentInChildren<MajorName>();
        majorName.SetMajorName(majorSO.majorName);
    }
}
