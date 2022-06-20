using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : ILevelModel
{
    public LevelSO Config { get; private set; }

    public LevelState State { get; private set; } = LevelState.NonActive;

    public event Action OnLevelBegin;
    public event Action OnLevelComplete;

    public LevelModel(LevelSO config)
    {
        Config = config;
    }
    public void BeginLevel()
    {
        State = LevelState.Active;
        OnLevelBegin?.Invoke();
        Debug.Log("BeginLevel");
    }

    public void CompleteLevel()
    {
        State = LevelState.Completed;
        OnLevelComplete?.Invoke();
        Debug.Log("CompleteLevel");
    }
}

public interface ILevelModel
{
    LevelSO Config { get; }
    LevelState State { get; }

    event Action OnLevelBegin;
    event Action OnLevelComplete;

    void BeginLevel();
    void CompleteLevel();
}

public enum LevelState
{
    NonActive,
    Active,
    Completed
}