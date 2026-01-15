using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUICtrl : AnMonoBehaviour
{
    [SerializeField] protected ScoreText scoreText;
    public ScoreText ScoreText => scoreText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScoreText();
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
        bool active = newState == GameState.EndGame;
        this.SetActiveAllChildren(active);
        this.SetScore();
    }
    protected virtual void SetActiveAllChildren(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
    protected virtual void SetScore()
    {
        if (scoreText == null) return;

        if (QuizManager.Instance != null)
        {
            int score = QuizManager.Instance.Score;
            this.scoreText.SetScoreText(score);
        }
        else return;
    }
}
