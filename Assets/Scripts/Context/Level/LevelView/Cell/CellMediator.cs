using context.level;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMediator : Mediator
{
    [Inject] public CellView View { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    public override void OnRegister()
    {
        DrawEnemyHandler();
        OnEnemyWayDefinedSignal.AddListener(DrawEnemyHandler);
    }
    public override void OnRemove()
    {
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemyHandler);
    }
    private void DrawEnemyHandler()
    {
        View.DrawEnemyWay();
    }
}
