using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : ILevelModel
{
    public LevelSO Config { get; private set; }
    public EnemyWaySO EnemyWay { get; private set; }
    public LevelState State { get; private set; } = LevelState.NonActive;

    public LevelModel(LevelSO config)
    {
        Config = config;
        EnemyWay = config.EnemyWay;
    }
    public void BeginLevel()
    {
        State = LevelState.Active;
        Debug.Log("BeginLevel");
    }

    public void CompleteLevel()
    {
        State = LevelState.Completed;
        Debug.Log("CompleteLevel");
    }
}

public interface ILevelModel
{
    LevelSO Config { get; }
    EnemyWaySO EnemyWay { get; }
    LevelState State { get; }

    void BeginLevel();
    void CompleteLevel();
}

public enum LevelState
{
    NonActive,
    Active,
    Completed
}