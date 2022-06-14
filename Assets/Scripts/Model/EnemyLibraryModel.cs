using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLibraryModel
{
    private EnemySO _enemySettings;
    private int _actualHealth;

    /// <summary>
    /// �������� ����� ����������
    /// </summary>
    public int InitialEnemyHealth
    {
        get => _enemySettings.InitialHealth;
    }

    /// <summary>
    /// ���������� �������� �����
    /// </summary>
    public int ActualEnemyHealth
    {
        get => _actualHealth = InitialEnemyHealth;
        set => _actualHealth = value;
    }

    /// <summary>
    /// ��������� ���� ��� ������
    /// </summary>
    public int EnemyDamage
    {
        get => _enemySettings.Damage;
    }

    /// <summary>
    /// �������� ��������
    /// </summary>
    public float EnemySpeed
    {
        get => _enemySettings.Speed;
    }

    /// <summary>
    /// R��������� ������, ����������� ������ �� ��� ��������
    /// </summary>
    public int CoinsForKill
    {
        get => _enemySettings.CoinsForKill;
    }
}
