using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuView : BaseMenuView
{
    [SerializeField] private TMPro.TMP_Text _damageText;
    [SerializeField] private TMPro.TMP_Text _radiusText;
    [SerializeField] private TMPro.TMP_Text _speedText;

    public event Action<List<UpgradeButton>> OnUpgradeButtonCreated = delegate { };
    public void SetUpUpgradeButtons(List<UpgradeConfig> _list, TowerView activeView)
    {
        List<UpgradeButton> _tempList = new List<UpgradeButton>();

        foreach (var upgrade in _list)
        {
            GameObject newButton = (GameObject)Instantiate(Resources.Load(StaticName.UPGRADE_BUTTON_PATH));
            newButton.transform.SetParent(ParentPanel.transform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.localPosition = new Vector3(0, 0, 0);
            UpgradeButton b = newButton.GetComponent<UpgradeButton>();
            b.UpgradeConfig = upgrade;
            b.CostText.text = "Цена: " + upgrade.Cost;
            b.DamageUpgradeText.text = "Урон + " + upgrade.Damage;
            b.RadiusUpgradeText.text = "Радиус + " + upgrade.ShootRadius;
            b.SpeedUpgradeText.text = "Скорость + " + upgrade.ShootFrequency;
            b.ActiveView = activeView;
            _tempList.Add(b);
        }

        OnUpgradeButtonCreated?.Invoke(_tempList);
    }

    public void ShowTowerData(TowerModel tower)
    {
        _damageText.text = "Урон: " + tower.Damage;
        _radiusText.text = "Радиус: " + tower.ShootRadius;
        _speedText.text = "Скорость: " + tower.ShootFrequency;
    }
    public override void ClearMenu()
    {
        foreach(var button in GetComponentsInChildren<UpgradeButton>())
        {
            Destroy(button.gameObject);
        }
    }
}
