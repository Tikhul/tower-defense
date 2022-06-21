using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanelMediator : Mediator
{
    [Inject] public EndPanelView View { get; set; }
    [Inject] public ShowEndPanelSignal ShowEndPanelSignal { get; set; }

    public override void OnRegister()
    {
        ShowEndPanelSignal.AddListener(ShowEndPanel);
    }

    public override void OnRemove()
    {
        ShowEndPanelSignal.RemoveListener(ShowEndPanel);
    }
    private void ShowEndPanel()
    {
        View.Show();
    }
}
