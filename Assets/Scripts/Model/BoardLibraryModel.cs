using System.Collections.Generic;
using UnityEngine;

public class BoardLibraryModel : MonoBehaviour
{
    public static string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    private List<CellView> _currentCellList = new List<CellView>();
    private List<CellView> _allCellList = new List<CellView>();
    private List<List<CellView>> _winCombinations = new List<List<CellView>>();
    [SerializeField] private GameObject _boardParent;
    [SerializeField] private BoardScriptableObject _boardSettings;
    public List<CellView> AllCellList
    {
        get => _allCellList;
        set => _allCellList = value;
    }
    public List<CellView> CurrentCellList
    {
        get => _currentCellList;
        set => _currentCellList = value;
    }
    public List<List<CellView>> WinCombinations
    {
        get => _winCombinations;
        set => _winCombinations = value;
    }
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }
    public BoardScriptableObject BoardSettings
    {
        get => _boardSettings;
        set => _boardSettings = value;
    }
}

