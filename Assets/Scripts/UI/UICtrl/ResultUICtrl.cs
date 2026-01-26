using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ResultUICtrl : AnMonoBehaviour
{

    [SerializeField] protected ScoreText scoreText;
    public ScoreText ScoreText => scoreText;

    [SerializeField] protected NextLevelBtn nextLevelBtn;
    public NextLevelBtn NextLevelBtn => nextLevelBtn;

    [SerializeField] protected ReturnBtn returnBtn;
    public ReturnBtn ReturnBtn => returnBtn;

    [SerializeField] protected ReplayBtn replayBtn;
    public ReplayBtn ReplayBtn => replayBtn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScoreText();
        this.LoadNextLevelBtn();
        this.LoadReturnBtn();
        this.LoadReplayBtn();
    }
    protected virtual void LoadReplayBtn()
    {
        if (this.replayBtn != null) return;
        this.replayBtn = transform.GetComponentInChildren<ReplayBtn>();
    }
    protected virtual void LoadReturnBtn()
    {
        if (this.returnBtn != null) return;
        this.returnBtn = transform.GetComponentInChildren<ReturnBtn>();
    }
    protected virtual void LoadNextLevelBtn()
    {
        if (this.nextLevelBtn != null) return;
        this.nextLevelBtn = transform.GetComponentInChildren<NextLevelBtn>();
    }
    protected virtual void LoadScoreText()
    {
        if (this.scoreText != null) return;
        this.scoreText = transform.GetComponentInChildren<ScoreText>();
    }
}
