using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "ScriptableObjects/UpgradeConfig", order = 4)]
public class UpgradeConfig : Config
{
    [SerializeField] private int _upgradeDamage;
    [SerializeField] private float _upgradeRadius;
    [SerializeField] private float _upgradeFrequency;
    [SerializeField] private int _cost;

    /// <summary>
    /// ���� �����
    /// </summary>
    public int Damage => _upgradeDamage;

    /// <summary>
    /// ���������� ���������� ������� ��������
    /// </summary>
    public float ShootRadius => _upgradeRadius;

    /// <summary>
    /// ���������� ���������� ����������������
    /// </summary>
    public float ShootDelay => _upgradeFrequency;

    /// <summary>
    /// C�������� ���������
    /// </summary>
    public int Cost => _cost;
}


