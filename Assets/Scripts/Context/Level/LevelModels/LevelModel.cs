using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : ILevelModel
{
    public Dictionary<TowerView, TowerModel> TowerData { get; set; } = new Dictionary<TowerView, TowerModel> ();
    public LevelConfig Config { get; private set; }
    public EnemyWayModel EnemyWay { get; private set; }
    public LevelState State { get; private set; } = LevelState.NonActive;
    public WavePipelineModel LevelWaves { get; private set; }

    public LevelModel(LevelConfig config)
    {
        Config = config;
        EnemyWay = new EnemyWayModel(config.EnemyWay);
        LevelWaves = new WavePipelineModel(config.WavePipeline);
    }

    public void BeginLevel()
    {
        State = LevelState.Active;
        LevelWaves.Begin();
        Debug.Log("BeginLevel");
    }

    public void CompleteLevel()
    {
        State = LevelState.Completed;
        LevelWaves.End();
        Debug.Log("CompleteLevel");
    }
    public void RestartLevel()
    {
        LevelWaves.Restart();
        BeginLevel();
    }
}

public interface ILevelModel
{
    Dictionary<TowerView, TowerModel> TowerData { get; }
    LevelConfig Config { get; }
    EnemyWayModel EnemyWay { get; }
    WavePipelineModel LevelWaves { get; }
    LevelState State { get; }

    void BeginLevel();
    void CompleteLevel();
    void RestartLevel();
}

public enum LevelState
{
    NonActive,
    Active,
    Completed
}