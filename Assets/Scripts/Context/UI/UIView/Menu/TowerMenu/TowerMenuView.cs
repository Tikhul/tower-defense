using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenuView : BaseMenuView
{
    public event Action<TowerButton> OnTowerButtonCreated = delegate { };
    public void SetUpTowerButtons(List<TowerView> _list)
    {
        foreach (var tower in _list)
        {
            GameObject newButton = (GameObject)Instantiate(Resources.Load(StaticName.TOWER_BUTTON_PATH));

            newButton.transform.SetParent(ParentPanel.transform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.localPosition = new Vector3(0, 0, 0);
            TowerButton b = newButton.GetComponent<TowerButton>();
            b.TowerCostText.text = "Цена: " + tower.TowerCostText;
            b.TowerDamageText.text = "Урон: " + tower.TowerDamageText;
            b.TowerRadiusText.text = "Радиус: " + tower.TowerRadiusText;
            b.TowerFrequencyText.text = "Скорость: " + tower.TowerFrequencyText;
            b.TowerBulletsText.text = "Враги: " + tower.TowerBulletsText;
            b.TowerButtonImage.sprite = tower.GetComponentInChildren<Image>().sprite;
            b.TowerView = tower;
            OnTowerButtonCreated?.Invoke(b);
        }
    }
    public override void ClearMenu()
    {
        Debug.Log("ClearMenu");
        foreach(var button in GetComponentsInChildren<TowerButton>())
        {
            Destroy(button.gameObject);
        }
    }
}
