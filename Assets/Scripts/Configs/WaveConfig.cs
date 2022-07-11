using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "ScriptableObjects/WaveConfig", order = 5)]
public class WaveConfig : Config
{
    [SerializeField] private float _waveHold;
    [SerializeField] private Dictionary<EnemyConfig, int> _enemiesAmounts;

    /// <summary>
    /// �������� ����� ������� ��������� ������ � �����
    /// </summary>
    public float WaveHold => _waveHold;

    /// <summary>
    /// ������� � �����: ���� ����� - ���������� � �����
    /// </summary>
    public Dictionary<EnemyConfig, int> EnemiesAmounts => _enemiesAmounts;
}
