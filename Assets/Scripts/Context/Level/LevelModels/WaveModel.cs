using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveModel : IWaveModel
{
    public WaveSO Config { get; private set; }
    public Dictionary<EnemySO, int> EnemiesAmounts { get; private set; } = new Dictionary<EnemySO, int>();
    public WaveState State { get; private set; } = WaveState.NonActive;

    public WaveModel(WaveSO _config)
    {
        Config = _config;
        EnemiesAmounts = _config.EnemiesAmounts;
    }

    public void BeginWave()
    {
        throw new System.NotImplementedException();
    }

    public void CompleteWave()
    {
        throw new System.NotImplementedException();
    }
}

public interface IWaveModel
{
    WaveSO Config { get; }
    Dictionary<EnemySO, int> EnemiesAmounts { get; }
    WaveState State { get; }
    void BeginWave();
    void CompleteWave();
}

public enum WaveState
{
    NonActive,
    Active,
    Completed
}