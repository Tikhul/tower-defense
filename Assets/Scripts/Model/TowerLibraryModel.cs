using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLibraryModel
{
    private TowerSO towerSettings;

    /// <summary>
    /// ���� �����
    /// </summary>
    public int TowerDamage
    {
        get => towerSettings.Damage;
    }

    /// <summary>
    /// ������ ��������
    /// </summary>
    public float ShootRadius
    {
        get => towerSettings.ShootRadius;
    }

    /// <summary>
    /// ���������������� (���������� ����� ����������)
    /// </summary>
    public float ShootFrequency
    {
        get => towerSettings.ShootFrequency;
    }

    /// <summary>
    /// C������ ������ ������� �� ���
    /// </summary>
    public int BulletsNumber
    {
        get => towerSettings.BulletsNumber;
    }

    /// <summary>
    /// ��������� ���������
    /// </summary>
    public int TowerCost
    {
        get => towerSettings.Cost;
    }

    /// <summary>
    /// ��������� ��� ������� ����������
    /// </summary>
    public List<UpgradeSO> Upgrades
    {
        get => towerSettings.Upgrades;
    }
}
