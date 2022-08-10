using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerHealthCommand : Command
{
    [Inject] public EnemyView EnemyView { get; set; }
    public override void Execute()
    {
        injectionBinder.GetInstance<GameModel>().Player.ActualHealth -= EnemyView.Config.Damage;
        injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(injectionBinder.GetInstance<GameModel>().Player);
        if(injectionBinder.GetInstance<GameModel>().Player.ActualHealth <= 0)
        {
            injectionBinder.GetInstance<ShowRestartPanelSignal>().Dispatch();
        }
    }
}
