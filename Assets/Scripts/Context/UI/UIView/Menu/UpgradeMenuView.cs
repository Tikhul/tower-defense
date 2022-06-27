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
            GameObject newButton = (GameObject)Instantiate(Resources.Load(StaticName.UPGRADE_BUTTON_PATH));

            newButton.transform.SetParent(ParentPanel.transform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.localPosition = new Vector3(0, 0, 0);
            UpgradeButton b = newButton.GetComponent<UpgradeButton>();
            b.CostText.text = "Цена: " + upgrade.Config.Cost;
            b.DamageUpgradeText.text = "Урон + " + upgrade.Config.Damage;
            b.RadiusUpgradeText.text = "Радиус + " + upgrade.Config.ShootRadius;
            b.SpeedUpgradeText.text = "Скорость + " + upgrade.Config.ShootFrequency;
        }
    }
}
