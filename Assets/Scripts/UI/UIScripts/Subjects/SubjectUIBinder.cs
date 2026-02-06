using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectUIBinder : AnMonoBehaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();
        if (GameStateManager.Instance == null) return;
        GameStateManager.Instance.OnStateChanged += UnlockLevel;
        this.UnlockLevel(GameState.None,GameStateManager.Instance.CurrentState);
    }
    protected virtual void UnlockLevel(GameState oldState, GameState currentState)
    {
        
    }
}
