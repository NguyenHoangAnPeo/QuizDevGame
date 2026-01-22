using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ResultUICtrl : AnMonoBehaviour
{
    protected static ResultUICtrl instance;
    public static ResultUICtrl Instance => instance;

    [SerializeField] protected ScoreText scoreText;
    public ScoreText ScoreText => scoreText;

    [SerializeField] protected NextLevelBtn nextLevelBtn;
    public NextLevelBtn NextLevelBtn => nextLevelBtn;

    [SerializeField] protected ReturnBtn returnBtn;
    public ReturnBtn ReturnBtn => returnBtn;

    [SerializeField] protected ReplayBtn replayBtn;
    public ReplayBtn ReplayBtn => replayBtn;
    protected override void Awake()
    {
        base.Awake();
        ResultUICtrl.instance = this;
    }
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
    protected override void OnEnable()
    {
        base.OnEnable();
        if (GameStateManager.Instance == null) return;
        GameStateManager.Instance.OnStateChanged += HandleStateChanged;
        this.HandleStateChanged(GameState.None, GameStateManager.Instance.CurrentState);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (GameStateManager.Instance == null) return;
        GameStateManager.Instance.OnStateChanged -= HandleStateChanged;
    }
    protected virtual void HandleStateChanged(GameState oldState, GameState newState)
    {
        bool isActive = newState == GameState.EndGame;

        if (QuizManager.Instance == null) return;
        int score = QuizManager.Instance.Score;
        bool isWin = score >= 5;

        EnumResult result = isWin ? EnumResult.Win : EnumResult.Lose;

        this.ShowResult(isActive, result, score);
        
    }
    protected virtual void SetScore(int score)
    {
        if (scoreText == null) return;

        if (QuizManager.Instance != null)
        {
            this.scoreText.SetScoreText(score);
        }
        else return;
    }
    public virtual void ShowResult(bool value, EnumResult result,int score)
    {
        this.SetScore(score);
        bool isWin = result == EnumResult.Win;

        nextLevelBtn.gameObject.SetActive(isWin);
        replayBtn.gameObject.SetActive(value);
        returnBtn.gameObject.SetActive(value);
        scoreText.gameObject.SetActive(value);
    }
}
