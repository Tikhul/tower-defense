using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeScriptableObject", menuName = "ScriptableObjects/UpgradeSO", order = 4)]
public class UpgradeSO : Config
{
    [SerializeField] private int _upgradeDamage;
    [SerializeField] private float _upgradeRadius;
    [SerializeField] private int _upgradeFrequency;
    [SerializeField] private int _upgradeBulletsNumber;
    [SerializeField] private int _cost;

    /// <summary>
    /// Урон башни
    /// </summary>
    public int Damage
    {
        get => _upgradeDamage;
        set => _upgradeDamage = value;
    }

    /// <summary>
    /// Показатель увеличения радиуса стрельбы
    /// </summary>
    public float ShootRadius
    {
        get => _upgradeRadius;
        set => _upgradeRadius = value;
    }

    /// <summary>
    /// Показатель увеличения скорострельности
    /// </summary>
    public int ShootFrequency
    {
        get => _upgradeFrequency;
        set => _upgradeFrequency = value;
    }

    /// <summary>
    /// Показатель увеличения урона
    /// </summary>
    public int BulletsNumber
    {
        get => _upgradeBulletsNumber;
        set => _upgradeBulletsNumber = value;
    }

    /// <summary>
    /// Cтоимость улучшения
    /// </summary>
    public int Cost
    {
        get => _cost;
        set => _cost = value;
    }
}


