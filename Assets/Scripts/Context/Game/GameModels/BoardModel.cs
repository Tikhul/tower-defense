using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    private List<CellButtonView> _currentCellList = new List<CellButtonView>();
    private List<CellButtonView> _allCellList = new List<CellButtonView>();
    public BoardSO Settings { get; }

    public BoardModel (BoardSO settings)
    {
        Settings = settings;
    }

    /// <summary>
    /// ��� ������
    /// </summary>
    public List<CellButtonView> AllCellList
    {
        get => _allCellList;
        set => _allCellList = value;
    }

    /// <summary>
    /// ���������� ������ ������
    /// </summary>
    public List<CellButtonView> CurrentCellList
    {
        get => _currentCellList;
        set => _currentCellList = value;
    }
}
