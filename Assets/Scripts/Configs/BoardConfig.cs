using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BoardConfig", menuName = "ScriptableObjects/BoardConfig", order = 8)]
public class BoardConfig : Config
{
    [SerializeField] private int _rowNumber = 3;
    [SerializeField] private GameObject _buttonExample;
    [SerializeField] private GameObject _parentPanel;
    [SerializeField] private GameObject _rows;
    [SerializeField] private GameObject _columns;

    public int RowNumber
    {
        get => _rowNumber;
        set => _rowNumber = value;
    }
    public GameObject ButtonExample
    {
        get => _buttonExample;
        set => _buttonExample = value;
    }
    public GameObject ParentPanel
    {
        get => _parentPanel;
        set => _parentPanel = value;
    }
    public GameObject Rows
    {
        get => _rows;
        set => _rows = value;
    }
    public GameObject Columns
    {
        get => _columns;
        set => _columns = value;
    }
}

