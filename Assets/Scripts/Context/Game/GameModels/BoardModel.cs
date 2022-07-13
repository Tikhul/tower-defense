using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    private List<CellButtonView> _currentCellList = new List<CellButtonView>();
    private List<CellButtonView> _allCellList = new List<CellButtonView>();
    public BoardConfig Settings { get; set; }

    public void Initialize (BoardConfig settings)
    {
        Settings = settings;
    }

    /// <summary>
    /// Все кнопки
    /// </summary>
    public List<CellButtonView> AllCellList
    {
        get => _allCellList;
        set => _allCellList = value;
    }

    /// <summary>
    /// Актуальный список кнопок
    /// </summary>
    public List<CellButtonView> CurrentCellList
    {
        get => _currentCellList;
        set => _currentCellList = value;
    }
}
