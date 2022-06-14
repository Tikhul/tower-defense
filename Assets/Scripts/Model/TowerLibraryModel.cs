using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLibraryModel
{
    private TowerSO towerSettings;

    /// <summary>
    /// Урон башни
    /// </summary>
    public int TowerDamage
    {
        get => towerSettings.Damage;
    }

    /// <summary>
    /// Радиус стрельбы
    /// </summary>
    public float ShootRadius
    {
        get => towerSettings.ShootRadius;
    }

    /// <summary>
    /// Скорострельность (промежуток между выстрелами)
    /// </summary>
    public float ShootFrequency
    {
        get => towerSettings.ShootFrequency;
    }

    /// <summary>
    /// Cколько врагов атакует за раз
    /// </summary>
    public int BulletsNumber
    {
        get => towerSettings.BulletsNumber;
    }

    /// <summary>
    /// Стоимость постройки
    /// </summary>
    public int TowerCost
    {
        get => towerSettings.Cost;
    }

    /// <summary>
    /// Улучшения для данного сооружения
    /// </summary>
    public List<UpgradeSO> Upgrades
    {
        get => towerSettings.Upgrades;
    }
}
