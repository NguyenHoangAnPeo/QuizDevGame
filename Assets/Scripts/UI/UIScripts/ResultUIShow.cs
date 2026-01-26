using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ResultUIShow : AnMonoBehaviour
{
    [SerializeField] protected ResultUICtrl resultUICtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadResultUICtrl();
    }
    protected virtual void LoadResultUICtrl()
    {
        this.resultUICtrl = transform.GetComponent<ResultUICtrl>();
    }
    protected virtual void SetScore(int score)
    {
        if (resultUICtrl.ScoreText == null) return;

        if (QuizManager.Instance != null)
        {
            resultUICtrl.ScoreText.SetScoreText(score);
        }
        else return;
    }
    public virtual void ShowResult(bool value, EnumResult result, int score)
    {
        if (resultUICtrl == null) return;

        this.SetScore(score);
        bool isWin = result == EnumResult.Win;

        resultUICtrl.NextLevelBtn.gameObject.SetActive(isWin);
        resultUICtrl.ReplayBtn.gameObject.SetActive(value);
        resultUICtrl.ReturnBtn.gameObject.SetActive(value);
        resultUICtrl.ScoreText.gameObject.SetActive(value);
    }
}
