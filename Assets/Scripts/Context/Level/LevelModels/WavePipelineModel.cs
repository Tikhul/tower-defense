using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WavePipelineModel
{
    private List<IWaveModel> _waveModels { get; set; }
    public WavePipelineConfig Config { get; set; }
    public IWaveModel CurrentWave => _waveModels.LastOrDefault(e => e.State.Equals(WaveState.Active) || e.State.Equals(WaveState.Completed));
    public List<EnemyView> EnemiesOnScene { get; set; } = new List<EnemyView>();
    public event Action OnPipelineBegin;
    public event Action OnPipelineComplete;
    public WavePipelineModel(WavePipelineConfig _config)
    {
        Config = _config;
    }
    private IWaveModel GetNextWave()
    {
        if (CurrentWave == null) return _waveModels.FirstOrDefault();

        var index = _waveModels.IndexOf(CurrentWave);
        index++;

        if (_waveModels.Count <= index)
        {
            return null;
        }
        return _waveModels[index];
    }
    public void Begin()
    {
        _waveModels = Config.GetWaveModels();
        var first = GetNextWave();
        first.BeginWave();
        OnPipelineBegin?.Invoke();
        Debug.Log("Begin wave");
    }
    public void End()
    {
        foreach (var wave in _waveModels.Where(x => x.State == WaveState.Active))
        {
            wave.CompleteWave();
        }
        OnPipelineComplete?.Invoke();
        Debug.Log("End wave");
    }

    public void BeginNextWave()
    {
        var nextWave = GetNextWave();
        if (nextWave == null)
        {
            End();
            return;
        }
        nextWave.BeginWave();
        Debug.Log("BeginNextWave " + nextWave.Config.Id);
    }

    public void CompleteCurrentWave()
    {
        CurrentWave.CompleteWave();
        Debug.Log("CompleteCurrentWave " + CurrentWave.Config.Id);
    }
    public void Restart()
    {
        CurrentWave.CompleteWave();
        foreach (var wave in _waveModels.Where(x => x.State != WaveState.NonActive))
        {
            wave.RestartWave();
        }
    }
}
