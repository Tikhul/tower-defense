using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScriptableObject", menuName = "ScriptableObjects/WaveSO", order = 5)]
public class WaveSO : Config
{
    [SerializeField] private float _waveHold;
    [SerializeField] private Dictionary<EnemySO, int> _enemiesAmounts;

    /// <summary>
    /// �������� ����� ������� ��������� ������ � �����
    /// </summary>
    public float WaveHold
    {
        get => _waveHold;
        set => _waveHold = value;
    }

    /// <summary>
    /// ������� � �����: ���� ����� - ���������� � �����
    /// </summary>
    public Dictionary<EnemySO, int> EnemiesAmounts
    {
        get => _enemiesAmounts;
        set => _enemiesAmounts = value;
    }
}
