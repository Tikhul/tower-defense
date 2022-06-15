using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/LevelSO", order = 6)]
public class LevelSO : Config
{
    [SerializeField] private EnemyWaySO _enemyWay;
    [SerializeField] private List<WaveSO> _waves;

    /// <summary>
    /// Конфиг маршрута, по которому будут двигаться враги в уровне
    /// </summary>
    public EnemyWaySO EnemyWay
    {
        get => _enemyWay;
        set => _enemyWay = value;
    }

    /// <summary>
    /// Cписок волн, из которых состоит уровень
    /// </summary>
    public List<WaveSO> Waves
    {
        get => _waves;
        set => _waves = value;
    }
}
