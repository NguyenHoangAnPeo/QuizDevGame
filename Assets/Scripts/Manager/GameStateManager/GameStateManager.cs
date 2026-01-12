using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : AnMonoBehaviour
{
    protected static GameStateManager instance;
    public static GameStateManager Instance => instance;
    [SerializeField] public GameState CurrentState;

    public event Action<GameState, GameState> OnStateChanged; //old State, new State
    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        GameStateManager.instance = this;

        DontDestroyOnLoad(gameObject);


    }
    public virtual void SetState(GameState newState)
    {
        if (CurrentState == newState) return;

        GameState oldState = CurrentState;
        this.CurrentState = newState;

        Debug.Log("GameState -> " + newState);

        OnStateChanged?.Invoke(oldState, newState);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
}
