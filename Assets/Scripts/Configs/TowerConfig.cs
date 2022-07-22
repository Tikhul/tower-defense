using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "ScriptableObjects/TowerConfig", order = 3)]
public class TowerConfig : Config
{
    [SerializeField] private int _damage;
    [SerializeField] private float _shootRadius;
    [SerializeField] private float _ShootDelay;
    [SerializeField] private int _bulletsNumber;
    [SerializeField] private int _cost;
    [SerializeField] private List<UpgradeConfig> _upgrades;

    /// <summary>
    /// Урон башни
    /// </summary>
    public int Damage => _damage;

    /// <summary>
    /// Радиус стрельбы
    /// </summary>
    public float ShootRadius => _shootRadius;

    /// <summary>
    /// Скорострельность (промежуток между выстрелами)
    /// </summary>
    public float ShootDelay => _ShootDelay;

    /// <summary>
    /// Cколько врагов атакует за раз
    /// </summary>
    public int BulletsNumber => _bulletsNumber;

    /// <summary>
    /// Стоимость постройки
    /// </summary>
    public int Cost => _cost;

    /// <summary>
    /// Улучшения для данного сооружения
    /// </summary>
    public List<UpgradeConfig> Upgrades => _upgrades;
}

