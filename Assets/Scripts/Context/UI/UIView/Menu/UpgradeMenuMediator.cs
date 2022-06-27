using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuMediator : Mediator
{
    [Inject] public UpgradeMenuView View { get; set; }
    [Inject] public UpgradeMenuCreatedSignal UpgradeMenuCreatedSignal { get; set; }

    public override void OnRegister()
    {
        UpgradeMenuCreatedSignal.AddListener(SetUpUpgradeButtonsHandler);
    }
    public override void OnRemove()
    {
        UpgradeMenuCreatedSignal.RemoveListener(SetUpUpgradeButtonsHandler);
    }
    private void SetUpUpgradeButtonsHandler(List<UpgradeModel> _list)
    {
        View.SetUpUpgradeButtons(_list);
        View.Show();
    }
}
