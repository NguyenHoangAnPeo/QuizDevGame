using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MajorBtn : BaseBtn
{
    [SerializeField] protected float sceneLoadDelay = 0.12f;

    [SerializeField] protected MajorUICtrl majorUICtrl;
    public MajorUICtrl MajorUICtrl => majorUICtrl;

    protected bool isHandlingClick;

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
        StartCoroutine(this.StartSubjScene());
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
    protected virtual void SetOnClick()
    {
        if (MajorManager.Instance == null) return;
        MajorManager.Instance.SetMajorSO(majorUICtrl.MajorSO);
    }
    IEnumerator StartSubjScene()
    {
        GameManager.Instance.EndTransitionScene();

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("SubjectSelect");
    }
}
