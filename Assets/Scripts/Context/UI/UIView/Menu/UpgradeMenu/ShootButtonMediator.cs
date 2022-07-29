using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButtonMediator : Mediator
{
    [Inject] public ShootButtonView View { get; set; }
    [Inject] public BlockShootButtonSignal BlockShootButtonSignal { get; set; }
    [Inject] public UnBlockShootButtonSignal UnBlockShootButtonSignal { get; set; }
    public override void OnRegister()
    {
        BlockShootButtonSignal.AddListener(BlockShootButtonHandler);
        UnBlockShootButtonSignal.AddListener(UnblockShootButtonHandler);
    }
    public override void OnRemove()
    {
        BlockShootButtonSignal.RemoveListener(BlockShootButtonHandler);
        UnBlockShootButtonSignal.RemoveListener(UnblockShootButtonHandler);
    }
    private void BlockShootButtonHandler()
    {
        View.BlockButton();
    }
    private void UnblockShootButtonHandler()
    {
        View.UnblockButton();
    }
}
