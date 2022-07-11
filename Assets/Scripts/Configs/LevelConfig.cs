using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig", order = 6)]
public class LevelConfig : Config
{
    [SerializeField] private string _name;
    [SerializeField] private EnemyWayConfig _enemyWay;
    [SerializeField] private WavePipelineConfig _wavePipeline;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    /// <summary>
    /// ������ ��������, �� �������� ����� ��������� ����� � ������
    /// </summary>
    public EnemyWayConfig EnemyWay
    {
        get => _enemyWay;
        set => _enemyWay = value;
    }

    /// <summary>
    /// �������� ����, �� ������� ������� �������
    /// </summary>
    public WavePipelineConfig WavePipeline
    {
        get => _wavePipeline;
        set => _wavePipeline = value;
    }
}
