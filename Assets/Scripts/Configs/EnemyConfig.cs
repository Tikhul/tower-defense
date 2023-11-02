using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 2)]
public class EnemyConfig : Config
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _coinsForKill;

    /// <summary>
    /// ��������� �������� �����
    /// </summary>
    public int InitialHealth => _initialHealth;

    /// <summary>
    /// ��������� ���� ��� ������
    /// </summary>
    public int Damage => _damage;

    /// <summary>
    /// �������� ��������
    /// </summary>
    public float Speed => _speed;

    /// <summary>
    /// R��������� ������, ����������� ������ �� ��� ��������
    /// </summary>
    public int CoinsForKill => _coinsForKill;
}
