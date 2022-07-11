using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "ScriptableObjects/TowerConfig", order = 3)]
public class TowerConfig : Config
{
    [SerializeField] private int _damage;
    [SerializeField] private float _shootRadius;
    [SerializeField] private float _shootFrequency;
    [SerializeField] private int _bulletsNumber;
    [SerializeField] private int _cost;
    [SerializeField] private List<UpgradeConfig> _upgrades;

    /// <summary>
    /// ���� �����
    /// </summary>
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    /// <summary>
    /// ������ ��������
    /// </summary>
    public float ShootRadius
    {
        get => _shootRadius;
        set => _shootRadius = value;
    }

    /// <summary>
    /// ���������������� (���������� ����� ����������)
    /// </summary>
    public float ShootFrequency
    {
        get => _shootFrequency;
        set => _shootFrequency = value;
    }

    /// <summary>
    /// C������ ������ ������� �� ���
    /// </summary>
    public int BulletsNumber
    {
        get => _bulletsNumber;
        set => _bulletsNumber = value;
    }

    /// <summary>
    /// ��������� ���������
    /// </summary>
    public int Cost
    {
        get => _cost;
        set => _cost = value;
    }

    /// <summary>
    /// ��������� ��� ������� ����������
    /// </summary>
    public List<UpgradeConfig> Upgrades
    {
        get => _upgrades;
        set => _upgrades = value;
    }
}

