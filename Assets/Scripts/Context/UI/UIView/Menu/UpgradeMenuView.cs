using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuView : BaseMenuView
{
    [Inject] public UpgradeMenuCreatedSignal UpgradeMenuCreatedSignal { get; set; }

    public void SetUpUpgradeButtons(List<UpgradeModel> _list)
    {
        foreach (var upgrade in _list)
        {
            GameObject newButton = (GameObject)Instantiate(Resources.Load(StaticName.TOWER_BUTTON_PATH));

            newButton.transform.SetParent(ParentPanel.transform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.localPosition = new Vector3(0, 0, 0);
            TowerButton b = newButton.GetComponent<TowerButton>();
        }
    }
}
