using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerSO", order = 1)]
public class PlayerConfig : Config
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _initialCoins;

    /// <summary>
    /// ��������� �������� ������
    /// </summary>
    public int InitialHealth => _initialHealth;

    /// <summary>
    /// ��������� ���������� ������
    /// </summary>
    public int InitialCoins => _initialCoins;
}
