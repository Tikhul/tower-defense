using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWayConfig", menuName = "ScriptableObjects/EnemyWayConfig", order = 6)]
public class EnemyWayConfig : Config
{
    [SerializeField] private List<string> _indexes;

    /// <summary>
    /// Индексы клеток, по которым идет маршрут врагов
    /// </summary>
    public List<string> Indexes => _indexes;
}
