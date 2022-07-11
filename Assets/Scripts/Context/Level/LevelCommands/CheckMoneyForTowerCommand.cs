using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMoneyForTowerCommand : Command
{
    [Inject] public TowerButton TowerButton { get; set; }
    private GameModel GameModel => injectionBinder.GetInstance<GameModel>();

    public override void Execute()
    {
        if(TowerButton.TowerView.TowerConfig.Cost > GameModel.Player.ActualCoins)
        {
            Debug.Log("Недостаточно денег");
            injectionBinder.GetInstance<NoMoneySignal>().Dispatch();
            Fail();
        }
        else
        {
            GameModel.Player.ActualCoins -= TowerButton.TowerView.TowerConfig.Cost;
            injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(GameModel.Player);
            injectionBinder.GetInstance<TowerBoughtSignal>().Dispatch(TowerButton);
        }
    }
}
