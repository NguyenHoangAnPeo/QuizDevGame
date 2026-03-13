using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : AnMonoBehaviour
{
    [Header("Base Btn")]
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        this.AddOnclickEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtn();
    }
    protected virtual void LoadBtn()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();

        if (this.button == null)
        {
            this.button = GetComponentInChildren<Button>();
        }

        if (this.button != null)
        {
            Debug.LogWarning($"[BaseBtn] LoadBtn {this.button.name} in {this.gameObject.name}");
        }
        else
        {
            Debug.LogError($"[BaseBtn] Missing Button component in {this.gameObject.name}");
        }
    }
    protected virtual void AddOnclickEvent()
    {
        if (this.button == null) return;    
        this.button.onClick.RemoveListener(this.HandleClick);
        this.button.onClick.AddListener(this.HandleClick);
    }

    protected virtual void HandleClick()
    {
        this.PlayClickFeedback();
        this.OnClick();
    }
    protected virtual IEnumerator CoHandleClickWithDelay(float delay)
    {
        this.PlayClickFeedback();

        if (delay > 0f)
        {
            yield return new WaitForSecondsRealtime(delay);
        }

        this.OnClick();
    }


    protected virtual void PlayClickFeedback()
    {
        UIAnimationUtil.PunchScale(this, transform, 0.06f, 0.12f);
    }
    protected abstract void OnClick();
}