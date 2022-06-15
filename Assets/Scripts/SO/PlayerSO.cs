using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerSO", order = 1)]
public class PlayerSO : Config
{
    [SerializeField] private string _id;
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _initialCoins;

    public string Id
    {
        get => _id;
        set => _id = value;
    }
    /// <summary>
    /// ��������� �������� ������
    /// </summary>
    public int InitialHealth
    {
        get => _initialHealth;
        set => _initialHealth = value;
    }

    /// <summary>
    /// ��������� ���������� ������
    /// </summary>
    public int InitialCoins
    {
        get => _initialCoins;
        set => _initialCoins = value;
    }
}
