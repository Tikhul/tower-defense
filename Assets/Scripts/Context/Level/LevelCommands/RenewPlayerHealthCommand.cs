using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewPlayerHealthCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<GameModel>().Player.ActualHealth = injectionBinder.GetInstance<GameModel>().Player.InitialHealth;
        injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(injectionBinder.GetInstance<GameModel>().Player);
    }
}
