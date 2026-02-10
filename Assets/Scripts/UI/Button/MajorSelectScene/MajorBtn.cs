using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MajorBtn : BaseBtn
{
    [SerializeField] protected MajorUICtrl majorUICtrl;
    public MajorUICtrl MajorUICtrl => majorUICtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMajorUICtrl();
    }
    protected virtual void LoadMajorUICtrl()
    {
        if (this.majorUICtrl != null) return;
        this.majorUICtrl = transform.GetComponentInParent<MajorUICtrl>();
    }
    protected override void OnClick()
    {
        this.SetOnClick();
        SceneManager.LoadScene("SubjectSelect");
    }
    protected virtual void SetOnClick()
    {
        if (MajorManager.Instance == null) return;
        MajorManager.Instance.SetMajorSO(majorUICtrl.MajorSO);
    }
}
