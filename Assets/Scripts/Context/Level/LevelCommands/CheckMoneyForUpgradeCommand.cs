using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMoneyForUpgradeCommand : Command
{
    [Inject] public UpgradeButton UpgradeButton { get; set; }

    public override void Execute()
    {
        
    }
}
