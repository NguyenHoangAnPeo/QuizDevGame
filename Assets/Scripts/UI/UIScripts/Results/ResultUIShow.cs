using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ResultUIShow : AnMonoBehaviour
{
    [SerializeField] protected ResultUICtrl resultUICtrl;
    [SerializeField] protected CanvasGroup canvasGroup;

    protected Coroutine scoreAnimRoutine;

    protected override void Start()
    {
        base.Start();
        this.HideResult();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadResultUICtrl();
        this.LoadCanvasGroup();
    }

    protected virtual void LoadResultUICtrl()
    {
        this.resultUICtrl = transform.GetComponent<ResultUICtrl>();
    }

    protected virtual void LoadCanvasGroup()
    {
        if (canvasGroup != null) return;
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    protected virtual void SetScore(int score)
    {
        if (resultUICtrl.ScoreText == null) return;

        if (scoreAnimRoutine != null) StopCoroutine(scoreAnimRoutine);
        scoreAnimRoutine = StartCoroutine(AnimateScoreRoutine(score));
    }

    protected virtual IEnumerator AnimateScoreRoutine(int targetScore)
    {
        int current = 0;
        float duration = 0.5f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            current = Mathf.RoundToInt(Mathf.Lerp(0, targetScore, time / duration));
            resultUICtrl.ScoreText.SetScoreText(current);
            yield return null;
        }

        resultUICtrl.ScoreText.SetScoreText(targetScore);
    }

    public virtual void ShowResult(bool value, EnumResult result, int score)
    {
        if (resultUICtrl == null) return;

        bool isWin = result == EnumResult.Win;

        resultUICtrl.NextLevelBtn.gameObject.SetActive(value && isWin);
        resultUICtrl.ReplayBtn.gameObject.SetActive(value);
        resultUICtrl.ReturnBtn.gameObject.SetActive(value);
        resultUICtrl.ScoreText.gameObject.SetActive(value);
        resultUICtrl.panelBlock.SetActive(value);

        if (value)
        {
            canvasGroup.alpha = 0f;
            UIAnimationUtil.FadeCanvasGroup(this, canvasGroup, 1f, 0.2f);
            UIAnimationUtil.ScaleIn(this, resultUICtrl.ScoreText.transform, 0.2f);
            this.SetScore(score);
        }
        else
        {
            UIAnimationUtil.FadeCanvasGroup(this, canvasGroup, 0f, 0.15f);
        }

        Debug.Log("Show result thanh cong");
    }

    public virtual void HideResult()
    {
        if (resultUICtrl == null) return;

        resultUICtrl.NextLevelBtn.gameObject.SetActive(false);
        resultUICtrl.ReplayBtn.gameObject.SetActive(false);
        resultUICtrl.ReturnBtn.gameObject.SetActive(false);
        resultUICtrl.ScoreText.gameObject.SetActive(false);
        resultUICtrl.panelBlock.SetActive(false);

        if (canvasGroup != null) canvasGroup.alpha = 0f;
    }
}