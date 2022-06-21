using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameMediator : Mediator
{
    [Inject] public LevelNameView View { get; set; }
    [Inject] public LoadGameContextSignal LoadGameContextSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public ShowEndPanelSignal ShowEndPanelSignal { get; set; }

    public override void OnRegister()
    {
        NextLevelChosenSignal.AddListener(ShowPanelHandler);
        RestartLevelChosenSignal.AddListener(ShowPanelHandler);
        LoadGameContextSignal.AddListener(ShowPanelHandler);
        ShowRestartPanelSignal.AddListener(HidePanelHandler);
        ShowEndPanelSignal.AddListener(HidePanelHandler);
    }

    public override void OnRemove()
    {
        NextLevelChosenSignal.RemoveListener(ShowPanelHandler);
        RestartLevelChosenSignal.RemoveListener(ShowPanelHandler);
        LoadGameContextSignal.RemoveListener(ShowPanelHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanelHandler);
        ShowEndPanelSignal.RemoveListener(HidePanelHandler);
    }
    private void HidePanelHandler()
    {
        View.Hide();
    }

    private void ShowPanelHandler()
    {
        View.Show();
    }
}
