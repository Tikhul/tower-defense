using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsPipelineModel
{
    public List<ILevelModel> LevelModels { get; set; }
    public LevelsPipelineConfig Config { get; set; }
    public ILevelModel CurrentLevel => LevelModels.LastOrDefault(e => e.State.Equals(LevelState.Active) 
                                                                      || e.State.Equals(LevelState.Completed));
    public event Action OnPipelineBegin;
    public event Action OnPipelineComplete;

    private ILevelModel GetNextLevel()
    {
        if (CurrentLevel == null) return LevelModels.FirstOrDefault();

        var index = LevelModels.IndexOf(CurrentLevel);
        index++;

        if (LevelModels.Count <= index)
        {
            return null;
        }
        return LevelModels[index];
    }
    public void Begin()
    {
        LevelModels = Config.GetLevelModels();
        var first = GetNextLevel();
        first.BeginLevel();
        OnPipelineBegin?.Invoke();
        Debug.Log("Begin");
    }

    public void End()
    {
        foreach (var level in LevelModels.Where(x => x.State == LevelState.Active))
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
       CurrentLevel.EnemyWay.ClearEnemyWaysTransforms();
       Debug.Log("CompleteCurrentLevel " + CurrentLevel.Config.Name);
    }

    public void RestartLevel()
    {
        CurrentLevel.RestartLevel();
        Debug.Log("RestartLevel " + CurrentLevel.Config.Name);
    }
}
