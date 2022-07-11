using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "ScriptableObjects/WaveConfig", order = 5)]
public class WaveConfig : Config
{
    [SerializeField] private float _waveHold;
    [SerializeField] private Dictionary<EnemyConfig, int> _enemiesAmounts;

    /// <summary>
    /// Задержка перед началом появления врагов в волне
    /// </summary>
    public float WaveHold => _waveHold;

    /// <summary>
    /// Словарь в форме: типа врага - количество в волне
    /// </summary>
    public Dictionary<EnemyConfig, int> EnemiesAmounts => _enemiesAmounts;
}
