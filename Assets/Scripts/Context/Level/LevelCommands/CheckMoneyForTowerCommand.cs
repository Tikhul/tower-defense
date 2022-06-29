using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMoneyForTowerCommand : Command
{
    [Inject] public TowerButton TowerButton { get; set; }
    [Inject] public GameModel GameModel { get; set; }

    public override void Execute()
    {
        if(TowerButton.TowerView.TowerSO.Cost > GameModel.Player.ActualCoins)
        {
            Debug.Log("Недостаточно денег");
            injectionBinder.GetInstance<NoMoneySignal>().Dispatch();
            Fail();
        }
        else
        {
            GameModel.Player.ActualCoins -= TowerButton.TowerView.TowerSO.Cost;
            injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(GameModel.Player);
            injectionBinder.GetInstance<TowerBoughtSignal>().Dispatch(TowerButton);
        }
    }
}
