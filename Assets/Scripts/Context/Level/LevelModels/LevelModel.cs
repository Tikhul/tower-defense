using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : ILevelModel
{
    public LevelSO Config { get; private set; }
    public EnemyWayModel EnemyWay { get; private set; }
    public LevelState State { get; private set; } = LevelState.NonActive;
    public WavePipelineModel LevelWaves { get; private set; }

    public LevelModel(LevelSO config)
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
}

public interface ILevelModel
{
    LevelSO Config { get; }
    EnemyWayModel EnemyWay { get; }
    WavePipelineModel LevelWaves { get; }
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