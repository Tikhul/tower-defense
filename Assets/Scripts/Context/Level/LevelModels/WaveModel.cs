using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveModel : IWaveModel
{
    public WaveSO Config { get; private set; }
    public Dictionary<EnemySO, int> EnemiesAmounts { get; private set; } = new Dictionary<EnemySO, int>();
    public WaveState State { get; private set; } = WaveState.NonActive;

    public event Action OnWaveBegin;
    public event Action OnWaveComplete;

    public WaveModel(WaveSO _config)
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
    WaveSO Config { get; }
    Dictionary<EnemySO, int> EnemiesAmounts { get; }
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