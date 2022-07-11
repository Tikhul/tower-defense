using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveModel : IWaveModel
{
    public WaveConfig Config { get; private set; }
    public Dictionary<EnemyConfig, int> EnemiesAmounts { get; private set; } = new Dictionary<EnemyConfig, int>();
    public WaveState State { get; private set; } = WaveState.NonActive;

    public event Action OnWaveBegin;
    public event Action OnWaveComplete;

    public WaveModel(WaveConfig _config)
    {
        Config = _config;
        EnemiesAmounts = _config.EnemiesAmounts;
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
    Dictionary<EnemyConfig, int> EnemiesAmounts { get; }
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