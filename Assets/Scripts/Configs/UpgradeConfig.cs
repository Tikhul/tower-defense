using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "ScriptableObjects/UpgradeConfig", order = 4)]
public class UpgradeConfig : Config
{
    [SerializeField] private int _upgradeDamage;
    [SerializeField] private float _upgradeRadius;
    [SerializeField] private float _upgradeFrequency;
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
    /// Cтоимость улучшения
    /// </summary>
    public int Cost => _cost;
}


