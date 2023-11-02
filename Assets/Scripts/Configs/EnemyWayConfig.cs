using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWayConfig", menuName = "ScriptableObjects/EnemyWayConfig", order = 6)]
public class EnemyWayConfig : Config
{
    [SerializeField] private List<string> _indices;

    /// <summary>
    /// Индексы клеток, по которым идет маршрут врагов
    /// </summary>
    public List<string> Indices => _indices;
}
