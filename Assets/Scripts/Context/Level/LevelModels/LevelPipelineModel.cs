using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsPipelineModel
{
    private List<ILevelModel> _levelModels { get; set; }
    private bool _isComplete;
    public LevelsPipelineSO Config { get; set; }
    public ILevelModel CurrentLevel => _levelModels.LastOrDefault(e => e.State.Equals(LevelState.Active) || e.State.Equals(LevelState.Completed));
    public event Action OnPipelineBegin;
    public event Action OnPipelineComplete;

    //public event Action<ILevelModel> OnLevelBegin;
    //public event Action<ILevelModel> OnLevelComplete;

    private ILevelModel GetNextLevel()
    {
        if (CurrentLevel == null) return _levelModels.FirstOrDefault();

        var index = _levelModels.IndexOf(CurrentLevel);
        Debug.Log(index);
        index++;
        Debug.Log(index);

        if (index == _levelModels.Count)
        {
            return null;
        }
        
        return _levelModels[index];
    }
    public void Begin()
    {
        _isComplete = false;
        _levelModels = Config.GetLevelModels();
        var first = GetNextLevel();
        first.BeginLevel();
        OnPipelineBegin?.Invoke();
        Debug.Log("Begin");
    }

    public void End()
    {
        _isComplete = true;
        foreach (var level in _levelModels.Where(x => x.State == LevelState.Active))
        {
            level.CompleteLevel();
        }
        OnPipelineComplete?.Invoke();
        Debug.Log("End");
    }

    public void BeginNextLevel()
    {
        if (!_isComplete)
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
    }

    public void CompleteCurrentLevel()
    {
        if (!_isComplete)
        {
            CurrentLevel.CompleteLevel();
            Debug.Log("CompleteCurrentLevel");
        }
    }
}
