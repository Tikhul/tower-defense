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
    /// ���� �����
    /// </summary>
    public int Damage
    {
        get => _upgradeDamage;
        set => _upgradeDamage = value;
    }

    /// <summary>
    /// ���������� ���������� ������� ��������
    /// </summary>
    public float ShootRadius
    {
        get => _upgradeRadius;
        set => _upgradeRadius = value;
    }

    /// <summary>
    /// ���������� ���������� ����������������
    /// </summary>
    public int ShootFrequency
    {
        get => _upgradeFrequency;
        set => _upgradeFrequency = value;
    }

    /// <summary>
    /// ���������� ���������� �����
    /// </summary>
    public int BulletsNumber
    {
        get => _upgradeBulletsNumber;
        set => _upgradeBulletsNumber = value;
    }

    /// <summary>
    /// C�������� ���������
    /// </summary>
    public int Cost
    {
        get => _cost;
        set => _cost = value;
    }
}


