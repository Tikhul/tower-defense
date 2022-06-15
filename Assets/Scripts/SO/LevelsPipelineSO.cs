using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsPipelineScriptableObject", menuName = "ScriptableObjects/LevelsPipelineSO", order = 7)]

public class LevelsPipelineSO : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private List<LevelSO> _levels;
    public string Id => _id;
    public List<LevelSO> Levels => _levels;
}
