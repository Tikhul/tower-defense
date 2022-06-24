using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataView : BaseView
{
    [SerializeField] private TMPro.TMP_Text _healthText;
    [SerializeField] private TMPro.TMP_Text _coinsText;

    public TMPro.TMP_Text HealthText
    {
        get => _healthText;
        set => _healthText = value;
    }

    public TMPro.TMP_Text CoinsText
    {
        get => _coinsText;
        set => _coinsText = value;
    }

    public void ChangePlayerData(PlayerModel player)
    {
        HealthText.text = "Здоровье: " + player.ActualHealth;
        CoinsText.text = "Валюта: " + player.ActualCoins;
    }
}
