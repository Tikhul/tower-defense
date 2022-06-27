using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : ILevelModel
{
    public LevelSO Config { get; private set; }
    public EnemyWaySO EnemyWay { get; private set; }
    public LevelState State { get; private set; } = LevelState.NonActive;

    public Dictionary<TowerButton, TowerModel> TowerModels { get; set; } = new Dictionary<TowerButton, TowerModel>();

    public event Action OnLevelBegin;
    public event Action OnLevelComplete;

    public LevelModel(LevelSO config)
    {
        Config = config;
        EnemyWay = config.EnemyWay;
    }
    public void BeginLevel()
    {
        State = LevelState.Active;
        TowerModels.Clear();
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
    Dictionary<TowerButton, TowerModel> TowerModels { get; }
    LevelSO Config { get; }
    EnemyWaySO EnemyWay { get; }
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