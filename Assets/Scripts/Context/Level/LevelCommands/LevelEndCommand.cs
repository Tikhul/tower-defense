using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using context.level;
using UnityEngine;

public class LevelEndCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<HideMenuSignal>().Dispatch();
        
        if (injectionBinder.GetInstance<GameModel>().Player.ActualHealth <= 0)
        {
            injectionBinder.GetInstance<PipelineEndedSignal>().Dispatch();
        }
        else
        {
            injectionBinder.GetInstance<ShowRestartPanelSignal>().Dispatch();
        }
    }
}
