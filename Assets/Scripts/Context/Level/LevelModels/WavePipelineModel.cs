using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WavePipelineModel
{
    public List<IWaveModel> WaveModels { get; set; }
    public WavePipelineConfig Config { get; set; }
    public IWaveModel CurrentWave => WaveModels.LastOrDefault(e => e.State.Equals(WaveState.Active) || e.State.Equals(WaveState.Completed));
    public event Action OnPipelineBegin;
    public event Action OnPipelineComplete;
    public WavePipelineModel(WavePipelineConfig _config)
    {
        Config = _config;
    }
    private IWaveModel GetNextWave()
    {
        if (CurrentWave == null) return WaveModels.FirstOrDefault();

        var index = WaveModels.IndexOf(CurrentWave);
        index++;

        if (WaveModels.Count <= index)
        {
            return null;
        }
        return WaveModels[index];
    }
    public void Begin()
    {
        WaveModels = Config.GetWaveModels();
        var first = GetNextWave();
        first.BeginWave();
        OnPipelineBegin?.Invoke();
        Debug.Log("Begin wave");
    }
    public void End()
    {
        foreach (var wave in WaveModels.Where(x => x.State == WaveState.Active))
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
}
