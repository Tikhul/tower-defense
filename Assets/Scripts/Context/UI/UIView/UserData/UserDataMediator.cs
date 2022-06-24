using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataMediator : Mediator
{
    [Inject] public UserDataView View { get; set; }
    [Inject] public ChangePlayerDataSignal ChangePlayerDataSignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public ShowEndPanelSignal ShowEndPanelSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }

    public override void OnRegister()
    {
        ChangePlayerDataSignal.AddListener(ChangePlayerDataHandler);
        ShowRestartPanelSignal.AddListener(HidePanelHandler);
        ShowEndPanelSignal.AddListener(HidePanelHandler);
        NextLevelChosenSignal.AddListener(ShowPanelHandler);
        RestartLevelChosenSignal.AddListener(ShowPanelHandler);
    }

    public override void OnRemove()
    {
        ChangePlayerDataSignal.RemoveListener(ChangePlayerDataHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanelHandler);
        ShowEndPanelSignal.RemoveListener(HidePanelHandler);
        NextLevelChosenSignal.RemoveListener(ShowPanelHandler);
        RestartLevelChosenSignal.RemoveListener(ShowPanelHandler);
    }
    private void ChangePlayerDataHandler(PlayerModel player)
    {
        View.ChangePlayerData(player);
        View.Show();
    }

    private void ShowPanelHandler()
    {
        View.Show();
    }

    private void HidePanelHandler()
    {
        View.Hide();
    }
}
