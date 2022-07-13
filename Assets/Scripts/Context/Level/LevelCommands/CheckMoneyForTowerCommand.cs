using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Проверка, достаточно ли денег на покупку башни
/// </summary>
public class CheckMoneyForTowerCommand : Command
{
    [Inject] public TowerButtonView TowerButtonView { get; set; }
    private GameModel GameModel => injectionBinder.GetInstance<GameModel>();

    public override void Execute()
    {
        if(TowerButtonView.TowerView.TowerConfig.Cost > GameModel.Player.ActualCoins)
        {
            Debug.Log("Недостаточно денег");
            injectionBinder.GetInstance<NoMoneySignal>().Dispatch();
            Fail();
        }
        else
        {
            GameModel.Player.ActualCoins -= TowerButtonView.TowerView.TowerConfig.Cost;
            injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(GameModel.Player);
            injectionBinder.GetInstance<TowerBoughtSignal>().Dispatch();
        }
    }
}
