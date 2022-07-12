using context.main;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameMediator : Mediator
{
    [Inject] public LevelNameView View { get; set; }
    [Inject] public LevelContextLoadedSignal LevelContextLoadedSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public ShowEndPanelSignal ShowEndPanelSignal { get; set; }
    [Inject] public PassLevelDataSignal PassLevelDataSignal { get; set; }

    public override void OnRegister()
    {
        NextLevelChosenSignal.AddListener(ShowPanelHandler);
        RestartLevelChosenSignal.AddListener(ShowPanelHandler);
        LevelContextLoadedSignal.AddListener(ShowPanelHandler);
        PassLevelDataSignal.AddListener(ShowLevelNameHandler);
        ShowRestartPanelSignal.AddListener(HidePanelHandler);
        ShowEndPanelSignal.AddListener(HidePanelHandler);
    }

    public override void OnRemove()
    {
        NextLevelChosenSignal.RemoveListener(ShowPanelHandler);
        RestartLevelChosenSignal.RemoveListener(ShowPanelHandler);
        LevelContextLoadedSignal.RemoveListener(ShowPanelHandler);
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

    private void ShowLevelNameHandler(ILevelModel model)
    {
        View.ShowLevelName(model.Config.Name);
    }
}
