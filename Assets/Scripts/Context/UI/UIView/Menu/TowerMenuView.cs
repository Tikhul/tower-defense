using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenuView : BaseView
{
    [SerializeField] private GameObject _parentPanel;

    public void SetUpTowerButtons(List<TowerView> _list)
    {
        foreach (var tower in _list)
        {
            GameObject newButton = (GameObject)Instantiate(Resources.Load(StaticName.TOWER_BUTTON_PATH));
            newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(
                _parentPanel.GetComponent<RectTransform>().sizeDelta.x / _list.Count,
                _parentPanel.GetComponent<RectTransform>().sizeDelta.y
                );
            newButton.transform.SetParent(_parentPanel.transform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.localPosition = new Vector3(0, 0, 0);
            newButton.GetComponent<Image>().sprite = tower.TowerImage.sprite;
            TowerButton b = newButton.GetComponent<TowerButton>();
            b.TowerButtonText.text = tower.TowerText;
            b.TowerButtonImage.sprite = tower.GetComponentInChildren<Image>().sprite;
        }
    }

    public void ClearMenu()
    {
        Debug.Log("ClearMenu");
        foreach(var button in GetComponentsInChildren<TowerButton>())
        {
            Destroy(button.gameObject);
        }
    }
}
