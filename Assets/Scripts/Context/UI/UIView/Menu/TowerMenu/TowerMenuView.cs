using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenuView : BaseMenuView
{
    public event Action<TowerButtonView> OnTowerButtonCreated = delegate { };
    public void SetUpTowerButtons(List<TowerView> _list)
    {
        foreach (var tower in _list)
        {
            GameObject newButton = (GameObject)Instantiate(Resources.Load(StaticName.TOWER_BUTTON_PATH));

            newButton.transform.SetParent(ParentPanel.transform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.localPosition = new Vector3(0, 0, 0);
            TowerButtonView b = newButton.GetComponent<TowerButtonView>();
            b.TowerCostText.text = "????: " + tower.TowerCostText;
            b.TowerDamageText.text = "????: " + tower.TowerDamageText;
            b.TowerRadiusText.text = "??????: " + tower.TowerRadiusText;
            b.TowerFrequencyText.text = "????????: " + tower.TowerFrequencyText;
            b.TowerBulletsText.text = "?????: " + tower.TowerBulletsText;
            b.TowerButtonImage.sprite = tower.TowerImage;
            b.TowerView = tower;
        }
    }
    public override void ClearMenu()
    {
        foreach(var button in GetComponentsInChildren<TowerButtonView>())
        {
            Destroy(button.gameObject);
        }
    }
}
