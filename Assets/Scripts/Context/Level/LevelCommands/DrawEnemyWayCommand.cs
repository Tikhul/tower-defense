using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEnemyWayCommand : Command
{
    public override void Execute()
    {
        Debug.Log("DrawEnemyWayCommand");
        injectionBinder.GetInstance<DrawEnemyWaySignal>().Dispatch(injectionBinder.GetInstance<BoardModel>());
    }
}
