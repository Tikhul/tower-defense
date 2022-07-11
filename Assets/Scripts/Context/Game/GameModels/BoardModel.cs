using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    private List<CellButton> _currentCellList = new List<CellButton>();
    private List<CellButton> _allCellList = new List<CellButton>();
    public BoardConfig Settings { get; set; }

    public void Initialize (BoardConfig settings)
    {
        Settings = settings;
    }

    /// <summary>
    /// Все кнопки
    /// </summary>
    public List<CellButton> AllCellList
    {
        get => _allCellList;
        set => _allCellList = value;
    }

    /// <summary>
    /// Актуальный список кнопок
    /// </summary>
    public List<CellButton> CurrentCellList
    {
        get => _currentCellList;
        set => _currentCellList = value;
    }
}
