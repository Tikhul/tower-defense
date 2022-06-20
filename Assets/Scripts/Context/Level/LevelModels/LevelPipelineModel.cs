using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsPipelineModel
{
    public LevelsPipelineSO Config { get; set; }
    private List<ILevelModel> _levelModels => Config.GetLevelModels();
    public ILevelModel CurrentLevel => _levelModels.FirstOrDefault(e => e.State.Equals(LevelState.Active));

    public event Action OnPipelineBegin;
    public event Action OnPipelineComplete;

    public event Action<ILevelModel> OnLevelBegin;
    public event Action<ILevelModel> OnLevelComplete;

    private ILevelModel GetNextLevel()
    {
        if (CurrentLevel == null)
        {
            return _levelModels.FirstOrDefault();
        }

        Debug.Log("index");
        Debug.Log(CurrentLevel);

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
        Debug.Log("BeginNextLevel");
    }

    public void CompleteCurrentLevel()
    {
        CurrentLevel.CompleteLevel();
        Debug.Log("CompleteCurrentLevel");
    }
}
