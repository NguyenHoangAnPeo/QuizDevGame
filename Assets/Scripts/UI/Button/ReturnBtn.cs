using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnBtn : BaseBtn
{
    [SerializeField] protected float sceneLoadDelay = 0.12f;
    protected bool isHandlingClick;

    [SerializeField] protected string sceneReturnname;

    protected override void OnClick()
    {
        GameManager.Instance.EndTransitionScene();
        StartCoroutine(this.ReturnScene());
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
    IEnumerator ReturnScene()
    {
        GameManager.Instance.EndTransitionScene();

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene(this.sceneReturnname);
    }
}