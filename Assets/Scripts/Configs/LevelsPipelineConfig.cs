using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsPipelineConfig", menuName = "ScriptableObjects/LevelsPipelineConfig", order = 7)]

public class LevelsPipelineConfig : Config
{
    [SerializeField] private List<LevelConfig> _levels;
    public List<LevelConfig> Levels => _levels;

    public List<ILevelModel> GetLevelModels()
    {
        var list = new List<ILevelModel>();

        foreach(var level in _levels)
        {
            list.Add(new LevelModel(level));
        }

        return list;

    }
}
