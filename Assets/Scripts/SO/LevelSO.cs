using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/LevelSO", order = 6)]
public class LevelSO : Config
{
    [SerializeField] private string _name;
    [SerializeField] private EnemyWaySO _enemyWay;
    [SerializeField] private WavePipelineSO _wavePipeline;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    /// <summary>
    /// ������ ��������, �� �������� ����� ��������� ����� � ������
    /// </summary>
    public EnemyWaySO EnemyWay
    {
        get => _enemyWay;
        set => _enemyWay = value;
    }

    /// <summary>
    /// �������� ����, �� ������� ������� �������
    /// </summary>
    public WavePipelineSO WavePipeline
    {
        get => _wavePipeline;
        set => _wavePipeline = value;
    }
}
