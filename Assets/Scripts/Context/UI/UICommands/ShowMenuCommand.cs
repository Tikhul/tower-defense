using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenuCommand : Command
{
    [Inject] public CellState CellState { get; }
    public override void Execute()
    {
        Debug.Log("ShowMenuCommand");
    }
}
