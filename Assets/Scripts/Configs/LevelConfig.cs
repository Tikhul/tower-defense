using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig", order = 6)]
public class LevelConfig : Config
{
    [SerializeField] private string _name;
    [SerializeField] private EnemyWayConfig _enemyWay;
    [SerializeField] private WavePipelineConfig _wavePipeline;

    public string Name => _name;

    /// <summary>
    /// ������ ��������, �� �������� ����� ��������� ����� � ������
    /// </summary>
    public EnemyWayConfig EnemyWay => _enemyWay;

    /// <summary>
    /// �������� ����, �� ������� ������� �������
    /// </summary>
    public WavePipelineConfig WavePipeline => _wavePipeline;
}
