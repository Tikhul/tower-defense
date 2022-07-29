using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineEndCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<ShowEndPanelSignal>().Dispatch();
    }
}
