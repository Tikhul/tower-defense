using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 2)]
public class EnemyConfig : Config
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _coinsForKill;

    /// <summary>
    /// Начальное здоровье врага
    /// </summary>
    public int InitialHealth => _initialHealth;

    /// <summary>
    /// Наносимый урон для игрока
    /// </summary>
    public int Damage => _damage;

    /// <summary>
    /// Скорость движения
    /// </summary>
    public float Speed => _speed;

    /// <summary>
    /// Rоличество валюты, начисляемое игроку за его убийство
    /// </summary>
    public int CoinsForKill => _coinsForKill;
}
