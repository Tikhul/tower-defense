using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Рандомизированный список всех моделей врагов
    /// </summary>
    /// <returns></returns>
    public List<EnemyModel> GetEnemies()
    {
        List<EnemyModel> _tempList = new List<EnemyModel>();
        foreach (var data in _enemyData)
        {
            for(int i=0; i < data.Amount; i++)
            {
                _tempList.Add(new EnemyModel(data.Config));
            }
        }
        System.Random rng = new System.Random();
        
    return _tempList.OrderBy(a => rng.Next()).ToList();
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