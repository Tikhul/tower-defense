using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<ShowRestartPanelSignal>().Dispatch();
    }
}
