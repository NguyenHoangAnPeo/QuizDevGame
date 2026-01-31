using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ResultUIShow : AnMonoBehaviour
{
    [SerializeField] protected ResultUICtrl resultUICtrl;

    protected override void Start()
    {
        base.Start();
        this.HideResult();
    }
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

        resultUICtrl.NextLevelBtn.gameObject.SetActive(value && isWin);
        resultUICtrl.ReplayBtn.gameObject.SetActive(value);
        resultUICtrl.ReturnBtn.gameObject.SetActive(value);
        resultUICtrl.ScoreText.gameObject.SetActive(value);
        Debug.Log("Show result thanh cong");
    }
    public virtual void HideResult()
    {
        if (resultUICtrl == null) return;

        resultUICtrl.NextLevelBtn.gameObject.SetActive(false);
        resultUICtrl.ReplayBtn.gameObject.SetActive(false);
        resultUICtrl.ReturnBtn.gameObject.SetActive(false);
        resultUICtrl.ScoreText.gameObject.SetActive(false);
    }

}
