using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public int InitialCoins { get; }
    public int InitialHealth { get; }
    public PlayerModel(PlayerSO settings)
    {
        InitialCoins = settings.InitialCoins;
        InitialHealth = settings.InitialHealth;
    }
}
