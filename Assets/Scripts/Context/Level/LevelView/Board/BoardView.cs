using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : BaseView
{
    [SerializeField] private GameObject _boardParent;
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }

    private void OnEnable()
    {
        BoardParent.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void DrawEnemiesWays(List<CellButtonView> allButtons)
    {
        foreach(var button in allButtons)
        {
            if (button.State.Equals(CellState.HasTower))
            {
                button.ButtonElement.interactable = false;
                button.GetComponent<Image>().color = Color.blue;
                button.State = CellState.HasTower;
            }
            else
            {
                button.ButtonElement.interactable = true;
                button.GetComponent<Image>().color = Color.white;
                button.State = CellState.Empty;
            }
        }
        Debug.Log("DrawEnemiesWays");
    }
}
