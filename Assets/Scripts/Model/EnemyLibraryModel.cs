using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLibraryModel
{
    private EnemySO _enemySettings;
    private int _actualHealth;

    /// <summary>
    /// Здоровье врага изначально
    /// </summary>
    public int InitialEnemyHealth
    {
        get => _enemySettings.InitialHealth;
    }

    /// <summary>
    /// Актуальное здоровье врага
    /// </summary>
    public int ActualEnemyHealth
    {
        get => _actualHealth = InitialEnemyHealth;
        set => _actualHealth = value;
    }

    /// <summary>
    /// Наносимый урон для игрока
    /// </summary>
    public int EnemyDamage
    {
        get => _enemySettings.Damage;
    }

    /// <summary>
    /// Скорость движения
    /// </summary>
    public float EnemySpeed
    {
        get => _enemySettings.Speed;
    }

    /// <summary>
    /// Rоличество валюты, начисляемое игроку за его убийство
    /// </summary>
    public int CoinsForKill
    {
        get => _enemySettings.CoinsForKill;
    }
}
