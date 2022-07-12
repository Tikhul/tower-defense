using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "ScriptableObjects/WaveConfig", order = 5)]
public class WaveConfig : Config
{
    [SerializeField] private float _waveHold;
    [SerializeField] private List<EnemyData> _enemyData;

    /// <summary>
    /// Задержка перед началом появления врагов в волне
    /// </summary>
    public float WaveHold => _waveHold;
    /// <summary>
    /// Словарь с формате: модель врага - количество появлений в волне
    /// </summary>
    /// <returns></returns>
    public Dictionary<EnemyModel, int> GetEnemiesAmounts()
    {
        Dictionary<EnemyModel, int> dict = new Dictionary<EnemyModel, int>();
        foreach (var data in _enemyData)
        {
            dict.Add(new EnemyModel(data.Config), data.Amount);
        }
        return dict;
    }
}

[Serializable]
public class EnemyData
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private int _amount;
    public EnemyConfig Config => _config;
    public int Amount => _amount;
}