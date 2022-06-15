using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/EnemySO", order = 2)]
public class EnemySO : Config
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _coinsForKill;

    /// <summary>
    /// ��������� �������� �����
    /// </summary>
    public int InitialHealth
    {
        get => _initialHealth;
        set => _initialHealth = value;
    }

    /// <summary>
    /// ��������� ���� ��� ������
    /// </summary>
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    /// <summary>
    /// �������� ��������
    /// </summary>
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    /// <summary>
    /// R��������� ������, ����������� ������ �� ��� ��������
    /// </summary>
    public int CoinsForKill
    {
        get => _coinsForKill;
        set => _coinsForKill = value;
    }
}
