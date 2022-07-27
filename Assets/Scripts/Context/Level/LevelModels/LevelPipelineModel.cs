using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsPipelineModel
{
    private List<ILevelModel> _levelModels { get; set; }
    public LevelsPipelineConfig Config { get; set; }
    public ILevelModel CurrentLevel => _levelModels.LastOrDefault(e => e.State.Equals(LevelState.Active) || e.State.Equals(LevelState.Completed));
    public event Action OnPipelineBegin;
    public event Action OnPipelineComplete;

    private ILevelModel GetNextLevel()
    {
        if (CurrentLevel == null) return _levelModels.FirstOrDefault();

        var index = _levelModels.IndexOf(CurrentLevel);
        index++;

        if (_levelModels.Count <= index)
        {
            return null;
        }
        return _levelModels[index];
    }
    public void Begin()
    {
        _levelModels = Config.GetLevelModels();
        var first = GetNextLevel();
        first.BeginLevel();
        OnPipelineBegin?.Invoke();
        Debug.Log("Begin");
    }

    public void End()
    {
        foreach (var level in _levelModels.Where(x => x.State == LevelState.Active))
        {
            level.CompleteLevel();
        }
        OnPipelineComplete?.Invoke();
        Debug.Log("End");
    }

    public void BeginNextLevel()
    {
        var nextLevel = GetNextLevel();
        if (nextLevel == null)
        {
           End();
           return;
        }
        nextLevel.BeginLevel();
        Debug.Log("BeginNextLevel " + nextLevel.Config.Name);
    }

    public void CompleteCurrentLevel()
    {
       CurrentLevel.CompleteLevel();
       Debug.Log("CompleteCurrentLevel " + CurrentLevel.Config.Name);
    }

    public void RestartLevel()
    {
        CurrentLevel.RestartLevel();
        Debug.Log("RestartLevel " + CurrentLevel.Config.Name);
    }
}
