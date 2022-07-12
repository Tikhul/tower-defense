using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : BaseView
{
    [SerializeField] private GameObject _boardParent;
    [SerializeField] private Canvas _canvas;
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }

    private void OnEnable()
    {
        _canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void DrawEnemiesWays(List<CellButton> allButtons)
    {
        foreach (var button in allButtons)
        {
            if (button.State.Equals(CellState.EnemyWay))
            {
                button.ButtonElement.interactable = false;
                button.GetComponent<Image>().color = Color.blue;
            }
            else
            {
                button.ButtonElement.interactable = true;
                button.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void BlockBoard()
    {
        foreach(var cell in GetComponentsInChildren<CellButton>())
        {
            cell.ButtonElement.interactable = false;
        }
    }

    public void UnblockBoard()
    {
        foreach (var cell in GetComponentsInChildren<CellButton>())
        {
            if (!cell.State.Equals(CellState.EnemyWay))
            {
                cell.ButtonElement.interactable = true;
            }
        }
            
    }

    public void ClearTowers(List<CellButton> buttonsWithTower)
    {
        foreach (var button in buttonsWithTower)
        {
            foreach(var tower in button.Towers.TowerViews)
            {
                tower.gameObject.SetActive(false);
            }
        }
    }
}
