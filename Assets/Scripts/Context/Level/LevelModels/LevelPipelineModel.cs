using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsPipelineModel
{
    public LevelsPipelineSO Config { get; set; }
    private List<ILevelModel> _levelModels => Config.GetLevelModels();
    public ILevelModel CurrentStage => _levelModels.LastOrDefault(e => e.State.Equals(LevelState.Active) || e.State.Equals(LevelState.Completed));

    public event Action OnPipelineBegin;
    public event Action OnPipelineComplete;

    public event Action<ILevelModel> OnLevelBegin;
    public event Action<ILevelModel> OnLevelComplete;

    private ILevelModel GetNextLevel()
    {
        if (CurrentStage == null) return _levelModels.FirstOrDefault();
        var index = _levelModels.IndexOf(CurrentStage);
        index++;
        if (_levelModels.Count <= index) return null;
        return _levelModels[index];
    }

    public void Begin()
    {
        var first = GetNextLevel();
        first.BeginLevel();
        OnPipelineBegin?.Invoke();
    }

    public void End()
    {
        foreach (var stage in _levelModels.Where(x => x.State == LevelState.Active))
        {
            stage.CompleteLevel();
        }
        OnPipelineComplete?.Invoke();
    }

    public void BeginNextStage()
    {
        var nextStage = GetNextLevel();
        if (nextStage == null)
        {
            End();
            return;
        }
        nextStage.BeginLevel();
    }
}
