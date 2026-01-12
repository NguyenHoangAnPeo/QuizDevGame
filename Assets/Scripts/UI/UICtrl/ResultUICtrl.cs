using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUICtrl : AnMonoBehaviour
{
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
        SetActiveAllChildren(active);
    }
    protected virtual void SetActiveAllChildren(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}
