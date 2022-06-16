using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerSO", order = 1)]
public class PlayerSO : Config
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _initialCoins;

    /// <summary>
    /// Начальное здоровье игрока
    /// </summary>
    public int InitialHealth
    {
        get => _initialHealth;
        set => _initialHealth = value;
    }

    /// <summary>
    /// Начальное количество валюты
    /// </summary>
    public int InitialCoins
    {
        get => _initialCoins;
        set => _initialCoins = value;
    }
}
