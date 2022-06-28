using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowerCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<TowerUpgradedSignal>().Dispatch();
        Debug.Log("UpgradeTowerCommand");
    }
}
