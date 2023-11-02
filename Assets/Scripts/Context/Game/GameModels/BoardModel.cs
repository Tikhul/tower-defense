using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    private List<CellView> _currentCellList = new List<CellView>();
    private List<CellView> _allCellList = new List<CellView>();
    public BoardConfig Settings { get; set; }

    public void Initialize (BoardConfig settings)
    {
        Settings = settings;
    }

    /// <summary>
    /// Все кнопки
    /// </summary>
    public List<CellView> AllCellList
    {
        get => _allCellList;
        set => _allCellList = value;
    }

    /// <summary>
    /// Актуальный список кнопок
    /// </summary>
    public List<CellView> CurrentCellList
    {
        get => _currentCellList;
        set => _currentCellList = value;
    }
}
