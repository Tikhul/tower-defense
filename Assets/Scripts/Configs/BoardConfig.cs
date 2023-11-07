using UnityEngine;

[CreateAssetMenu(fileName = "BoardConfig", menuName = "ScriptableObjects/BoardConfig", order = 8)]
public class BoardConfig : Config
{
    [SerializeField] private int _rowNumber = 3;
    [SerializeField] private GameObject _buttonExample;
    [SerializeField] private GameObject _parentPanel;

    public int RowNumber => _rowNumber;
    public GameObject ButtonExample => _buttonExample;
    public GameObject ParentPanel => _parentPanel;
}

