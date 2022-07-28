using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewPlayerMoneyCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<GameModel>().Player.ActualCoins = injectionBinder.GetInstance<GameModel>().Player.InitialCoins;
        injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(injectionBinder.GetInstance<GameModel>().Player);
    }
}
