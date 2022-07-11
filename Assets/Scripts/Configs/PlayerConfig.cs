using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerSO", order = 1)]
public class PlayerConfig : Config
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _initialCoins;

    /// <summary>
    /// Начальное здоровье игрока
    /// </summary>
    public int InitialHealth => _initialHealth;

    /// <summary>
    /// Начальное количество валюты
    /// </summary>
    public int InitialCoins => _initialCoins;
}
