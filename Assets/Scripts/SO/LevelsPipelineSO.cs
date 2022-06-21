using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsPipelineScriptableObject", menuName = "ScriptableObjects/LevelsPipelineSO", order = 7)]

public class LevelsPipelineSO : Config
{
    [SerializeField] private List<LevelSO> _levels;
    public List<LevelSO> Levels => _levels;

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
