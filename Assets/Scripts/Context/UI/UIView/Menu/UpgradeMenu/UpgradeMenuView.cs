using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuView : BaseMenuView
{
    public event Action<UpgradeButton> OnUpgradeButtonCreated = delegate { };
    public void SetUpUpgradeButtons(List<UpgradeModel> _list, TowerView activeView)
    {
        Debug.Log(_list.Count);
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
            b.UpgradeData = upgrade;
            b.ActiveView = activeView;
            OnUpgradeButtonCreated?.Invoke(b);
        }
    }

    public override void ClearMenu()
    {
        foreach(var button in GetComponentsInChildren<UpgradeButton>())
        {
            Destroy(button.gameObject);
        }
    }
}
