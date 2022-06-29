using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningsMediator : Mediator
{
    [Inject] public WarningsView View { get; set; }
    [Inject] public NoMoneySignal NoMoneySignal { get; set; }

    public override void OnRegister()
    {
        NoMoneySignal.AddListener(NoMoneyHandler);
    }

    public override void OnRemove()
    {
        NoMoneySignal.RemoveListener(NoMoneyHandler);
    }

    private void NoMoneyHandler()
    {
        View.ShowWarning(View.NoMoneyWarning);
    }
}
