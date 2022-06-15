using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsPipelineScriptableObject", menuName = "ScriptableObjects/LevelsPipelineSO", order = 7)]

public class LevelsPipelineSO : Config
{
    [SerializeField] private List<LevelSO> _levels;
    public List<LevelSO> Levels => _levels;
}
