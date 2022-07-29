using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuView : BaseMenuView
{
    [SerializeField] private TMPro.TMP_Text _damageText;
    [SerializeField] private TMPro.TMP_Text _radiusText;
    [SerializeField] private TMPro.TMP_Text _speedText;
    [SerializeField] private ShootButtonView _shootButtonView;
    public ShootButtonView ShootButton => _shootButtonView;
    public void SetUpUpgradeButtonViews(List<UpgradeConfig> _list, TowerView activeView)
    {
        List<UpgradeButtonView> _tempList = new List<UpgradeButtonView>();

        foreach (var upgrade in _list)
        {
            GameObject newButton = (GameObject)Instantiate(Resources.Load(StaticName.UPGRADE_BUTTON_PATH));
            newButton.transform.SetParent(ParentPanel.transform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.localPosition = new Vector3(0, 0, 0);
            UpgradeButtonView b = newButton.GetComponent<UpgradeButtonView>();
            b.UpgradeConfig = upgrade;
            b.CostText.text = "Цена: " + upgrade.Cost;
            b.DamageUpgradeText.text = "Урон + " + upgrade.Damage;
            b.RadiusUpgradeText.text = "Радиус + " + upgrade.ShootRadius;
            b.SpeedUpgradeText.text = "Задержка - " + upgrade.ShootDelay;
            b.ActiveView = activeView;
            _tempList.Add(b);
        }
    }

    public void ShowTowerData(TowerModel tower)
    {
        _damageText.text = "Урон: " + tower.Damage;
        _radiusText.text = "Радиус: " + tower.ShootRadius;
        _speedText.text = "Задержка: " + tower.ShootDelay;
    }
    public override void ClearMenu()
    {
        foreach(var button in GetComponentsInChildren<UpgradeButtonView>())
        {
            Destroy(button.gameObject);
        }
    }
    
}
