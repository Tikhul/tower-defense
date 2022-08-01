using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "ScriptableObjects/UpgradeConfig", order = 4)]
public class UpgradeConfig : Config
{
    [SerializeField] private int _upgradeDamage;
    [SerializeField] private float _upgradeRadius;
    [SerializeField] private float _upgradeFrequency;
 //   [SerializeField] private int _upgradeBulletsNumber;
    [SerializeField] private int _cost;

    /// <summary>
    /// Урон башни
    /// </summary>
    public int Damage => _upgradeDamage;

    /// <summary>
    /// Показатель увеличения радиуса стрельбы
    /// </summary>
    public float ShootRadius => _upgradeRadius;

    /// <summary>
    /// Показатель увеличения скорострельности
    /// </summary>
    public float ShootDelay => _upgradeFrequency;

    /// <summary>
    /// Показатель увеличения урона
    /// </summary>
  //  public int BulletsNumber => _upgradeBulletsNumber;

    /// <summary>
    /// Cтоимость улучшения
    /// </summary>
    public int Cost => _cost;
}


