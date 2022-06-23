using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    private List<CellButton> _currentCellList = new List<CellButton>();
    private List<CellButton> _allCellList = new List<CellButton>();
    public BoardSO Settings { get; }

    public BoardModel (BoardSO settings)
    {
        Settings = settings;
    }

    /// <summary>
    /// ��� ������
    /// </summary>
    public List<CellButton> AllCellList
    {
        get => _allCellList;
        set => _allCellList = value;
    }

    /// <summary>
    /// ���������� ������ ������
    /// </summary>
    public List<CellButton> CurrentCellList
    {
        get => _currentCellList;
        set => _currentCellList = value;
    }
}
