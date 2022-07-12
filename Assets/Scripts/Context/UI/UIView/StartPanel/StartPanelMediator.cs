using context.main;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelMediator : Mediator
{
    [Inject] public StartPanelView View { get; set; }
    [Inject] public LoadContextsSignal LoadContextsSignal { get; set; }

    public override void OnRegister()
    {
        View.OnStartButtonClick += OnStartButtonClickHandler;
    }

    private void OnStartButtonClickHandler()
    {
        View.Hide();
        LoadContextsSignal.Dispatch();
    }
}
