using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveModel : IWaveModel
{
    public WaveConfig Config { get; private set; }
    public List<EnemyModel> WaveEnemies { get; private set; } = new List<EnemyModel>();
    public Dictionary<EnemyView, EnemyModel> EnemyData { get; set; } = 
        new Dictionary<EnemyView, EnemyModel>();
    public WaveState State { get; private set; } = WaveState.NonActive;

    public event Action OnWaveBegin;
    public event Action OnWaveComplete;

    public WaveModel(WaveConfig _config)
    {
        Config = _config;
        WaveEnemies = _config.GetEnemies();
    }
    public void BeginWave()
    {
        State = WaveState.Active;
        OnWaveBegin?.Invoke();
        Debug.Log("BeginWave " + Config.Id);
    }
    public void CompleteWave()
    {
        State = WaveState.Completed;
        OnWaveComplete?.Invoke();
        Debug.Log("CompleteWave " + Config.Id);
    }
}

public interface IWaveModel
{
    WaveConfig Config { get; }
    List<EnemyModel> WaveEnemies { get; }
    Dictionary<EnemyView, EnemyModel> EnemyData { get; }
    WaveState State { get; }
    void BeginWave();
    void CompleteWave();
    event Action OnWaveBegin;
    event Action OnWaveComplete;
}

public enum WaveState
{
    NonActive,
    Active,
    Completed
}