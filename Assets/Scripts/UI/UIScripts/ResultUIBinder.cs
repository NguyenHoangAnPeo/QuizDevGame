using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUIBinder : AnMonoBehaviour
{
    [SerializeField] protected ResultUIShow resultUIShow;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadResultUIShow();
    }
    protected virtual void LoadResultUIShow()
    {
        if (this.resultUIShow != null) return;
        this.resultUIShow = GetComponent<ResultUIShow>();
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
        EnumResult enumResult = QuizManager.Instance.EnumResult;
        resultUIShow.ShowResult(isActive, enumResult, score);
        Debug.Log("Da goi ham show result");
    }
}
