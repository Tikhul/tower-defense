using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWayScriptableObject", menuName = "ScriptableObjects/EnemyWaySO", order = 6)]
public class EnemyWaySO : Config
{
    [SerializeField] private List<string> _indexes;

    /// <summary>
    /// Индексы клеток, по которым идет маршрут врагов
    /// </summary>
    public List<string> Indexes
    {
        get => _indexes;
        set => _indexes = value;
    }
}
